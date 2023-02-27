using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace Attributes_and_Reflection
{
    class PlayerListAttributConstain
    {
        public static void run()
        {

        List<Player> PlayerList = new List<Player>
            {
                new Player{Name="a",Speed=20,Power=50,passing=20,Dribbling=30 },
                new Player{Name="b",Speed=312,Power=33,passing=319,Dribbling=330 },
                new Player{Name="c",Speed=31,Power=5330,passing=31,Dribbling=313 },

            };
        List<Error> Errors = new List<Error>();
        Player p = new Player { Name = "c", Speed = 31, Power = 10, passing = 31, Dribbling = 10 };
        Console.WriteLine(Validate_Player(p));

            //loop through each player , then get the properties of each player object ,then check if the properity
            //has SkillAttribute , if yes get the value of that property for that player ,and send it for validation
            foreach (Player player in PlayerList)
            {
                PropertyInfo[] Properties =player.GetType().GetProperties();
                foreach (PropertyInfo property in Properties)
                {
                    SkillAttribute Skill=property.GetCustomAttribute<SkillAttribute>();
                    if(Skill != null)
                    {
                        int value = (int)property.GetValue(player);
                        bool is_valid=Skill.IsValid(value);
                        if (!is_valid)
                        {
                           Console.WriteLine($"{player.Name} has unvalid values {property.Name}");
                           Errors.Add(new Error(property.Name, $"valid range is {Skill.Minvalue} to {Skill.Maxvalue}"));
                        }
                    }
                }
            }

        }
        public static bool Validate_Player(Player player)
        {
            PropertyInfo[] Properties = player.GetType().GetProperties();
            foreach (PropertyInfo property in Properties)
            {
                SkillAttribute Skill = property.GetCustomAttribute<SkillAttribute>();
                if (Skill != null)
                {
                    int value = (int)property.GetValue(player);
                    bool is_valid = Skill.IsValid(value);
                    if (!is_valid)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
    

    
    class Player
    {
        public String Name { get; set; }
        [Skill("Speed",1,100)]
        public int Speed { get; set; }//1-100

        [Skill(nameof(Power), 1, 20)]
        public int Power { get; set; } // 1-20

        [Skill(nameof(passing), 1, 50)]
        public int passing { get; set; }//1-50

        [Skill(nameof(Dribbling), 1, 40)]
        public int Dribbling { get; set; } //1-40

    }
    class SkillAttribute:Attribute
    {
        public SkillAttribute(string name, int minvalue, int maxvalue)
        {
            Name = name;
            Maxvalue = maxvalue;
            Minvalue = minvalue;
        }

        public string Name { get; private set; }
        public int Maxvalue { get; private set; }
        public int Minvalue { get; private set; }

        public bool IsValid(int Value)
        { 
            return Value >= Minvalue && Value <= Maxvalue;
        } 


    }
    class Error
    {
        private string Details;
        private string Field;

        public Error(string field, string detail)
        {
            Details = detail;
            Field = field;
        }
        public override string ToString()
        {
            return $"{Field} : {Details}";
        }
    }
}

