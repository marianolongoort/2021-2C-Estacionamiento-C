using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstacionamientoMVC.Helpers
{
    public static class Alias
    {
        public const string DNI = "Documento";
        public const string Email = "Correo electrónico";
        public const string ClienteId = "Cliente";
        public const string PersonaId = "Persona";
        public const string Password = "Contraseña";
        public const string PassConfirm = "Confirmación de contraseña";
        public const string EmpleadoId = "Empleado";
        public const string VehiculoId = "Vehiculo";
        public const string Anio = "Año";
        public const string NombreCompleto = "Nombre completo";
        public const string RolName = "Nombre";
    }

    public static class AliasGUI
    {
        public static string Create { get { return "Crear"; } }
        public static string Delete { get { return "Eliminar"; } }
        public static string Edit { get { return "Editar"; } }
        public static string Details { get { return "Detalles"; } }
        public static string Back { get { return "Volver atras"; } }
        public static string BackToList { get { return "Volver al listado"; } }
        public static string SureToDelete { get { return "¿Está seguro que desa proceder con la eliminación?"; } }
        public static string ListOf { get { return "Listado de "; } }

        public static string Save { get { return "Guardar"; } }
    }
}
