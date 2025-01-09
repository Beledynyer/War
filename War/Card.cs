using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War
{
    internal class Card
    {
        private String description;
        private int value;

        public Card(int value,String description) { 
            this.value = value;
            this.description = description;
        }

        public String getDescription() { return description; }
        public int getValue() { return value; }
    }
}
