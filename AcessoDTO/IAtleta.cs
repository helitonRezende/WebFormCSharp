using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AcessoDTO
{
    public interface IAtleta<T>
    {
        DataTable ExibirTodos();
        List<T> Exibir();
        void Incluir(T obj);
        void Alterar(T obj);
        void Excluir(T obj);
        DataTable Consultar(string nome);
    }
}
