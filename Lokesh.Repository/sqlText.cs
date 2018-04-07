using System;
using System.Collections.Generic;
using System.Text;

namespace Lokesh.Repository
{
  public  class sqlText
    {
        public static string Inser_table_with =  "INSERT INTO Products (ProductId, Name, Quantity, Price)"
                                + " VALUES(@ProductId, @Name, @Quantity, @Price)";
        public static string danhmuc = "select @ a from @table ";
    }
}
