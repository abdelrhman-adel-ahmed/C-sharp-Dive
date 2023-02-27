using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstProjectEfCore;


internal class Program
{
    static async Task Main(string[] args)
    {
        //AddData();
        //Console.WriteLine("Hello, World!");
        //var factory = new CoockBookFactory();
        //await EntryState(factory);
        //await DetachedFromTracker(factory);

        //await AddDataForLego();
        await QueryLegoData();
    }
    static async Task EntryState(CoockBookFactory factory)
    {
        var dbContext = factory.CreateDbContext();
        var dish = new Dish { Title = "Foo", Notes = "Bar" };

        var state = dbContext.Entry(dish);
        dbContext.Add(dish);
        state = dbContext.Entry(dish);
        dbContext.SaveChanges();
        state = dbContext.Entry(dish);
        dish.Title = "dsadsa";
        state = dbContext.Entry(dish);
        dbContext.Remove(dish);
        state = dbContext.Entry(dish);

    }
    static async Task DetachedFromTracker(CoockBookFactory factory)
    {
        var dbContext = factory.CreateDbContext();
        var dish = new Dish { Title = "Foo", Notes = "Bar" };

        dbContext.Dishes.Update(dish);
        dbContext.SaveChanges();
        dbContext.Entry(dish).State = EntityState.Detached;
        var state = dbContext.Entry(dish).State;
        //how ef still know the id if the dish to do an update not an insert.
        dbContext.Dishes.Update(dish);
        dbContext.SaveChanges();
    }
    static void AddDataForDishes()
    {
        var factory = new CoockBookFactory();
        using (var context = factory.CreateDbContext())
        {
            var tt = context.Dishes.ToList();
            Console.WriteLine(tt[0].Ingredients);
            var obj = new Dish { Title = "BreakFast", Notes = "this is good", Stars = 4 };
            context.Dishes.Add(obj);
            context.SaveChanges();
            context.Dishes.Remove(obj);
            context.SaveChanges();
        }
    }

    static async Task AddDataForLego()
    {
        var factory = new CoockBookFactory();
        using var context = factory.CreateDbContext();
        Vendor brickKing, held;
        await context.AddRangeAsync(new[]
        {
            brickKing = new Vendor(){VendorName="Brick King"},
            held = new Vendor(){VendorName="Held"},
        });
        await context.SaveChangesAsync();

        Tag rare, ninjago, mincraft;
        await context.AddRangeAsync(new[] {
            rare = new Tag(){Title="rare"},
            ninjago= new Tag(){Title="ninjago"},
            mincraft= new Tag(){Title="mincraft"},
        });
        await context.SaveChangesAsync();


        //ef will handle every thing here (add objects graphs that will get translated to
        //multiple rows in the db and ef will get care of the relations)
        await context.AddAsync(new BasePlate
        {
            Title = "baseplate with 16 * 16",
            Color = color.Green,
            Tags = new List<Tag>() { rare, ninjago },
            Length = 16,
            Width = 16,
            Availability = new List<BrickAvailability>()
            {
               new() {Vendor=brickKing,AvailableAmount =5,Price=10},
               new() {Vendor=held,AvailableAmount =10,Price=15},
            }
        });
        await context.SaveChangesAsync();
        var state = context.Entry(rare);
        var orig = state.OriginalValues;
    }
    static async Task QueryLegoData()
    {
        var factory = new CoockBookFactory();
        using var context = factory.CreateDbContext();
        List<string> titles = new List<string>() { "baseplate with 16 * 16" };
        var tt = titles.FirstOrDefault();
        var xx = context.Bricks.Select(x => x.Title == titles.FirstOrDefault());
        //one to many
        var availabilites = await context.brickAvailabilities
            .Include(b => b.Brick)
            .Include(b => b.Vendor)
            .ToListAsync();
        foreach (var item in availabilites)
        {
            Console.WriteLine($"brick {item.Brick.Title} is available in vendor {item.Vendor.VendorName}" +
                $" with price {item.Price} and available amount are {item.AvailableAmount}");
        }
        Console.WriteLine();

        //many to many
        var brickWithVendorAndTags = await context.Bricks
            .Include(nameof(Brick.Availability) + "." + nameof(BrickAvailability.Vendor))
            .Include(b => b.Tags)
            .ToListAsync();

        foreach (var item in brickWithVendorAndTags)
        {
            if (item.Tags.Any()) Console.Write
                    ($"({string.Join(',', item.Tags.Select(t => t.Title))})");

            if (item.Availability.Any()) Console.Write
                    ($" is avilable at ({string.Join(',', item.Availability.Select(t => t.Vendor.VendorName))})");
        }

        #region load related data for specific item
        var simpleBricks = await context.Bricks.ToListAsync();

        foreach (var item in simpleBricks)
        {

            await context.Entry(item).Collection(c => c.Tags).LoadAsync();
            await context.Entry(item).Collection(c => c.Availability).LoadAsync();

            if (item.Tags.Any()) Console.Write
                    ($"({string.Join(',', item.Tags.Select(t => t.Title))})");

            if (item.Availability.Any()) Console.Write
                    ($" is avilable at ({string.Join(',', item.Availability.Select(t => t.Vendor.VendorName))})");
        }
        #endregion
    }
}

public class CoockBookContext : DbContext
{
    public DbSet<Dish> Dishes { get; set; }
    public DbSet<Brick> Bricks { get; set; }
    public DbSet<Vendor> Vendors { get; set; }
    public DbSet<BrickAvailability> brickAvailabilities { get; set; }
    public DbSet<Tag> Tags { get; set; }

    public CoockBookContext(DbContextOptions<CoockBookContext> options)
        : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelbuilder use to configure the mdoels (you can use fluentApi instead of
        //data annotations and you can do alot of things ...)

        //tell the ef that we want to store the drived class BasePlate that drived from brick
        modelBuilder.Entity<BasePlate>().HasBaseType<Brick>();
        modelBuilder.Entity<MinifigHead>().HasBaseType<Brick>();
    }
}
public class CoockBookFactory : IDesignTimeDbContextFactory<CoockBookContext>
{
    public CoockBookContext CreateDbContext(string[] args = null)
    {
        var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        var connectionString = config.GetConnectionString("localDb");
        var optionBuilder = new DbContextOptionsBuilder<CoockBookContext>();
        optionBuilder.UseSqlServer(connectionString).LogTo((e) => Console.WriteLine(e), LogLevel.Information);
        return new CoockBookContext(optionBuilder.Options);
    }
}
public class Dish
{
    public int Id { get; set; }

    [MaxLength(100)]
    public string Title { get; set; } = null!;

    [MaxLength(1000)]
    public string? Notes { get; set; }

    public int? Stars { get; set; }

    public List<DishIngredient> Ingredients { get; set; } = new();
}

public class DishIngredient
{
    public int Id { get; set; }

    [MaxLength(100)]
    public string Description { get; set; } = null!;

    [MaxLength(50)]
    public string UnitOfMeasure { get; set; } = null!;

    [Column(TypeName = "decimal(5,2)")] /*total length of 5 and 2 nubmer after the decimal point*/
    public decimal Amount { get; set; }

    public Dish? Dish { get; set; } //navigation property 

    public int DishId { get; set; } /*forignKey from the DishIngredient to the dish*/
}

public enum color
{
    Black,
    White,
    Red,
    Yellow,
    Orange,
    Green
}

#region Models
public class Brick
{
    public int Id { get; set; }

    [MaxLength(250)]
    public string Title { get; set; } = string.Empty;

    public color? Color { get; set; }

    public List<Tag> Tags { get; set; }

    public List<BrickAvailability> Availability { get; set; }

}

public class BasePlate : Brick   //tph we store the entire inheritance hierarchy in a single table 
                                 // diffrentiate using the Discriminator col
{
    public int Length { get; set; }

    public int Width { get; set; }
}
public class MinifigHead : Brick  //tph 
{
    public bool IsDualSided { get; set; }
}
public class Tag
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;

    public List<Brick> Bricks { get; set; }
}

public class Vendor
{
    public int Id { get; set; }

    [MaxLength(250)]
    public string VendorName { get; set; }

    public List<BrickAvailability> Availability { get; set; } //n part 
}

public class BrickAvailability
{
    public int Id { get; set; }

    public Vendor Vendor { get; set; } //one part of the relation
    public int VendorId { get; set; }  //one part of the relation

    public Brick Brick { get; set; }
    public int BrickId { get; set; }

    public int AvailableAmount { get; set; }

    [Column(TypeName = "decimal(8,2)")]
    public decimal Price { get; set; }

}
#endregion