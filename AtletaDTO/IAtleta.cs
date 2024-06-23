using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtletaDTO
{
    public interface IAtleta<T>
    {
        Atleta GetAtletaId(int id);
        DataTable ConsultarFiltro(AtletaFiltro obj);
        bool GetAtletaChave(int id, int nrocamisa);
        void Incluir(T obj);
        void Alterar(T obj);
        void Excluir(int id);
    }
}