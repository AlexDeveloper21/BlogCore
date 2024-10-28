using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Proyecto2.Data;
using Proyecto2.Models;
using Proyecto2.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2.AccesoDatos.Data.Inicializador
{
    public class InicializadorDB : IInicializadorBD
    {

        private readonly ApplicationDbContext _bd;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;


        public InicializadorDB(ApplicationDbContext bd, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager) { 
            
            _bd = bd;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void Inicializar()
        {
            try
            {
                if (_bd.Database.GetPendingMigrations().Count() > 0)
                {
                    _bd.Database.Migrate();
                }
            }
            catch (Exception)
            {
            }

            if (_bd.Roles.Any(ro => ro.Name == CNT.Administrador)) return;

            //Creacion de roles

            _roleManager.CreateAsync(new IdentityRole(CNT.Administrador)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(CNT.Registrado)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(CNT.Cliente)).GetAwaiter().GetResult();

            _userManager.CreateAsync(new ApplicationUser
            {
                UserName = "pruebadmin@gmail.com",
                Email = "pruebadmin@gmail.com",
                EmailConfirmed = true,
                Nombre = "PruebaAdmin",
            }, "Abc123*").GetAwaiter().GetResult();

            ApplicationUser usuario = _bd.ApplicationUser.Where(us => us.Email == "pruebadmin@gmail.com").FirstOrDefault();

            _userManager.AddToRoleAsync(usuario, CNT.Administrador).GetAwaiter().GetResult();
        }
    }
}
