using ListaVehiculos.web.Domain.Dto;
using ListaVehiculos.web.Infraestructure.Services;

namespace ListaVehiculos.web.Application.Services
{
    /// <summary>
    /// Interfaz para el servicio de vehiculos
    /// </summary>
    public interface IVehicleService
    {
        /// <summary>
        /// Consulta los vehiculos
        /// </summary>
        /// <returns>
        /// Una lista de los vehiculos
        /// </returns>
        public Task<List<VehicleDto>> Consultar();

        /// <summary>
        /// Elimina un vehiculo
        /// </summary>
        /// <returns>
        /// Una lista de vehiculos
        /// </returns>
        public Task<List<VehicleDto>> Eliminar(int Id);

        /// <summary>
        /// Guarda un vehiculo
        /// </summary>
        /// <returns>
        /// Una lista de vehiculos
        /// </returns>
        public Task<List<VehicleDto>> Guardar(VehicleDto vehiculo);
    }

    public class VehicleService(IJsonFileService<VehicleDto> jsonFileService) : IVehicleService
    {
        /// <summary>
        /// Nombre del archivo
        /// </summary>
        private readonly string archivo = "vehiculos";

        /// <summary>
        /// Guarda una vehiculo
        /// </summary>
        /// <param name="vehiculo">
        /// Representa el vehiculo a guardar
        /// </param>
        /// <returns>
        /// Una lista de vehiculos
        /// </returns>
        public async Task<List<VehicleDto>> Guardar(VehicleDto vehiculo)
        {
            /// Se obtienen los vehiculos
            var vehiculos = await jsonFileService.Leer(archivo);
            /// Se asigna un identificador al vehiculo
            vehiculo.Id = !vehiculos.Any() ? 1 : vehiculos.Max(x => x.Id) + 1;
            /// Se agrega el vehiculo a la lista
            vehiculos.Add(vehiculo);
            /// Se reescriben los vehiculos
            await jsonFileService.Escribir(archivo, vehiculos);
            /// Se retornan los vehiculos
            return vehiculos;
        }

        /// <summary>
        /// Consulta los vehiculos
        /// </summary>
        /// <returns>
        /// Una lista de vehiculos
        /// </returns>
        public async Task<List<VehicleDto>> Consultar()
        {
            /// Se obtienen los vehiculos  
            var vehiculos = await jsonFileService.Leer(archivo);
            /// Se retornan los vehiculos
            return vehiculos;
        }

        /// <summary>
        /// Elimina un vehiculo
        /// </summary>
        /// <param name="Id">
        /// Es el identificador del vehiculo a eliminar
        /// </param>
        /// <returns>
        /// Una lista de vehiculos
        /// </returns>
        public async Task<List<VehicleDto>> Eliminar(int Id)
        {
            /// Se obtienen los vehiculos
            var vehiculos = await jsonFileService.Leer(archivo);
            /// Se busca el vehiculo a eliminar
            var vehiculo = vehiculos.FirstOrDefault(x => x.Id == Id);
            /// Si el vehiculo existe, se elimina
            if (vehiculo != null)
            {
                /// Se elimina el vehiculo
                vehiculos.Remove(vehiculo);
                /// Se reescriben los vehiculos
                await jsonFileService.Escribir(archivo, vehiculos);
            }
            /// Se retornan los vehiculos
            return vehiculos;
        }
    }

}
