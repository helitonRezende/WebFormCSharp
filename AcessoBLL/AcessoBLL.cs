using System;
using System.Collections.Generic;
using System.Data;
using AcessoDAO;
using AcessoDTO;

namespace AcessoBLL
{
    public class AcessoBLL : IAtleta<Atleta>
    {
        public Atleta GetAtletaId(int id)
        {
            try
            {
                string sql = "SELECT Id,Nome,Endereco,Telefone,Email,Observacao FROM Atletas WHERE Id = " + id;
                DataTable tabela = new DataTable();
                tabela = AcessoDB.GetDataTable(sql);
                return GetAtleta(tabela);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Atleta GetAtleta(DataTable tabela)
            try
            {
                Atleta _Atleta = new Atleta();
                if (tabela.Rows.Count > 0)
                {
                    _Atleta.Id = Convert.ToInt32(tabela.Rows[0][0]);
                    //_Atleta.nome = Convert.ToString(tabela.Rows[0]["Nome"]);
                    //_Atleta.endereco = tabela.Rows[0][2].ToString();
                    //_Atleta.telefone = tabela.Rows[0][3].ToString();
                    //_Atleta.email = tabela.Rows[0][4].ToString();
                    //_Atleta.observacao = tabela.Rows[0][5].ToString();
                    return _Atleta;
                }
                else
                {
                    _Atleta = null;
                    return _Atleta;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Atleta> Exibir()
        {
            try
            {
                string sql = "SELECT * FROM Atletas";
                DataTable tabela = new DataTable();
                tabela = AcessoDB.GetDataTable(sql);
                return GetListaAtleta(tabela);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Atleta> GetListaAtleta(DataTable tabela)
        {
            try
            {
                List<Atleta> listaAtleta = new List<Atleta>();
                int i = 0;
                dynamic registros = tabela.Rows.Count;
                if (registros > 0)
                {
                    foreach (DataRow drRow in tabela.Rows)
                    {
                        Atleta _Atleta = new Atleta();
                        //_Atleta.Id = Convert.ToInt32(tabela.Rows[i][0]);
                        //_Atleta.nome = Convert.ToString(tabela.Rows[i]["Nome"]);
                        //_Atleta.endereco = tabela.Rows[i][2].ToString();
                        //_Atleta.telefone = tabela.Rows[i][3].ToString();
                        //_Atleta.email = tabela.Rows[i][4].ToString();
                        //_Atleta.observacao = tabela.Rows[i][5].ToString();
                        listaAtleta.Add(_Atleta);
                    }
                    while (i <= registros)
                    {
                        Atleta _Atleta = new Atleta();
                        //_Atleta.Id = Convert.ToInt32(tabela.Rows[i][0]);
                        //_Atleta.nome = Convert.ToString(tabela.Rows[i]["Nome"]);
                        //_Atleta.endereco = tabela.Rows[i][2].ToString();
                        //_Atleta.telefone = tabela.Rows[i][3].ToString();
                        //_Atleta.email = tabela.Rows[i][4].ToString();
                        //_Atleta.observacao = tabela.Rows[i][5].ToString();
                        listaAtleta.Add(_Atleta);
                        i += i;
                    }
                    return listaAtleta;
                }
                else
                {
                    listaAtleta = null;
                    return listaAtleta;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable ConsultarPorID(int id)
        {
            string sql = "SELECT Id,Nome,Endereco,Telefone,Email,Observacao FROM Atleta WHERE Id = " + id;
            try
            {
                return AcessoDB.GetDataTable(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Consultar(string nome)
        {
            string sql = "SELECT Id,Nome FROM Atleta WHERE Nome LIKE '" + nome + "%'" + " ORDER BY Nome";
            try
            {
                return AcessoDB.GetDataTable(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Incluir(Atleta oAtleta)
        {
            string sql = "";
            try
            {
                string[] parametrosNomes = new string[6];
                parametrosNomes[0] = "@Nome";
                parametrosNomes[1] = "@Endereco";
                parametrosNomes[2] = "@Telefone";
                parametrosNomes[3] = "@Email";
                parametrosNomes[4] = "@Observacao";
                string[] parametrosValores = new string[6];
                //parametrosValores[0] = oAtleta.nome;
                //parametrosValores[1] = oAtleta.endereco;
                //parametrosValores[2] = oAtleta.telefone;
                //
                //parametrosValores[3] = oAtleta.email;
                //parametrosValores[4] = oAtleta.observacao;
                sql = "INSERT INTO Atleta(Nome,Endereco,Telefone,Email,Observacao) values (@Nome,@Endereco,@Telefone,@Email,@Observacao)";
                AcessoDB.CRUD(sql, parametrosNomes, parametrosValores);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Alterar(Atleta oAtleta)
        {
            string sql = "";
            try
            {
                string[] parametrosNomes = new string[7];
                parametrosNomes[0] = "@Id";
                parametrosNomes[1] = "@Nome";
                parametrosNomes[2] = "@Endereco";
                parametrosNomes[3] = "@Telefone";
                parametrosNomes[4] = "@Email";
                parametrosNomes[5] = "@Observacao";
                string[] parametrosValores = new string[7];
                parametrosValores[0] = oAtleta.Id.ToString();
                //parametrosValores[1] = oAtleta.nome;
                //parametrosValores[2] = oAtleta.endereco;
                //parametrosValores[3] = oAtleta.telefone;
                //
                //parametrosValores[4] = oAtleta.email;
                //parametrosValores[5] = oAtleta.observacao;
                sql = "UPDATE Atleta SET Nome=@Nome, Endereco=@Endereco ,Telefone=@Telefone,Email=@Email , Observacao=@Observacao Where Id=@Id";
                AcessoDB.CRUD(sql, parametrosNomes, parametrosValores);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Excluir(Atleta oAtleta)
        {
            string sql = "";
            try
            {
                string[] parametrosNomes = new string[1];
                parametrosNomes[0] = "@Id";
                string[] parametrosValores = new string[1];
                parametrosValores[0] = oAtleta.Id.ToString();
                sql = "DELETE FROM Atleta Where Id=@Id";
                AcessoDB.CRUD(sql, parametrosNomes, parametrosValores);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ExibirTodos()
        {
            string sql = "SELECT * FROM Atletas";
            try
            {
                return AcessoDB.GetDataTable(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
