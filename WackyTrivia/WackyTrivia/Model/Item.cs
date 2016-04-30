using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace WackyTrivia.Model
{
    /*
     * Data model for an Item to be used in Game questions.
     * Author: Jesse Rowland
     */
    public class Item
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        public string Name { get; set; }
        //stored as USD value
        [NotNull]
        public double Value { get; set; }
    }
}
