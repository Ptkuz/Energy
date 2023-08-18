using Energy.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Energy.DAL.Context
{
    public static class ContextInitializer
    {

        public static Organization[] FillOrganizations()
        {
            return new Organization[]
            {
                new Organization("Организация 1", "Москва"),
                new Organization("Организация 2", "Новосибирск"),
                new Organization("Организация 3", "Москва"),
                new Organization("Организация 4", "Екатеринбург"),
                new Organization("Организация 5", "Москва")

            };
        }

        public static Organization[] FillOrganizations()
        {
            return new Organization[]
            {
                new Organization("Организация 1", "Москва"),
                new Organization("Организация 2", "Новосибирск"),
                new Organization("Организация 3", "Москва"),
                new Organization("Организация 4", "Екатеринбург"),
                new Organization("Организация 5", "Москва")

            };
        }
    }
}
