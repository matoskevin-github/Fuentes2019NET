using System.Collections.Generic;
using System.ServiceModel;
using WcfEscuelaCRUDADO.Net.Model;

namespace WcfEscuelaCRUDADO.Net
{

    [ServiceContract]
    public interface IServiceEscuela
    {
        [OperationContract]
        bool RegistrarMaestro(EscuelaBE oescuelaBE);

        [OperationContract]
        bool ActualizarMaestro(EscuelaBE oescuelaBE);

        [OperationContract]
        bool EliminarMaestro(EscuelaBE oescuelaBE);

        [OperationContract]
        List<EscuelaBE> ListarMaestros();

        [OperationContract]
        EscuelaBE ListarMaestroPorId(int idMaestro);

        [OperationContract]
        List<EscuelaBE> ListarMaestroPorCriterio(string Criterio);
    }
}
