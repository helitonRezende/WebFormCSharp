using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AtletaDTO;
using static AtletaDAO.AcessoDAO;

namespace AtletaBLL
{
    public class AcessoBLL : IAtleta<Atleta>
    {
        // Atleta por ID //
        public Atleta GetAtletaId(int id)
        {
            string sql = "SELECT Id, Nome, Apelido, Dtnascimento, Altura, Peso, Posicao, Nrocamisa ";
            sql += " FROM Atleta ";
            sql += " WHERE ID = " + id;
            DataTable tabela = new DataTable();
            tabela = AcessoDB.GetDataTable(sql);

            Atleta _Atleta = new Atleta();
            if (tabela.Rows.Count > 0)
            {
                _Atleta.Id = Convert.ToInt16(tabela.Rows[0]["Id"]);
                _Atleta.Nome = Convert.ToString(tabela.Rows[0]["Nome"]);
                _Atleta.Apelido = Convert.ToString(tabela.Rows[0]["Apelido"]);
                _Atleta.DtNascimento = Convert.ToDateTime(tabela.Rows[0]["DtNascimento"]);
                _Atleta.Altura = Convert.ToDecimal(tabela.Rows[0]["Altura"]);
                _Atleta.Peso = Convert.ToDecimal(tabela.Rows[0]["Peso"]);
                _Atleta.Posicao = Convert.ToString(tabela.Rows[0]["Posicao"]);
                _Atleta.NroCamisa = Convert.ToInt16(tabela.Rows[0]["NroCamisa"]);
                return _Atleta;
            }
            else
            {
                _Atleta = null;
                return _Atleta;
            }
        }
        // Atleta Filtros Tela //
        public DataTable ConsultarFiltro(AtletaFiltro oAtleta)
        {
            string sql = "SELECT id, Nrocamisa, Apelido, Posicao, ";
            sql += " DATEDIFF(YY, DtNascimento, GETDATE()) as 'Idade', ";
            sql += " Altura , Peso, ";
            sql += " cast(peso / (altura * altura) as decimal(10, 2)) as 'IMC', ";
            sql += " case ";
            sql += " when (peso / (altura * altura)) < 18.5 THEN 'Abaixo do peso normal'";
            sql += " when (peso / (altura * altura)) BETWEEN 18.5 AND 24.9 THEN 'Peso normal'";
            sql += " when (peso / (altura * altura)) BETWEEN 25 AND 29.9 THEN 'Excesso de peso'";
            sql += " when (peso / (altura * altura)) BETWEEN 30 AND 34.9 THEN 'Obsidade classe I'";
            sql += " when (peso / (altura * altura)) BETWEEN 35 AND 39.9 THEN 'Obsidade classe II'";
            sql += " when (peso / (altura * altura)) >= 40 THEN 'Obsidade classe III'";
            sql += " end as 'ClassificaIMC' ";
            sql += " FROM Atleta ";
            sql += " WHERE 1 = 1 ";

            if (oAtleta != null && oAtleta.NroCamisa > 0)
            {
                sql += " AND Nrocamisa = " + oAtleta.NroCamisa;
            }

            if (oAtleta != null && (oAtleta.Apelido != null && oAtleta.Apelido.ToString().Length > 0))
            {
                sql += " AND Apelido = '" + oAtleta.Apelido.ToString().Trim() + "'";
            }

            switch (oAtleta.ClassificaIMC.ToString().Trim())
            {
                case "1":
                    sql += " AND 1 = case when (peso / (altura * altura)) < 18.5 THEN 1 end ";
                    break;
                case "2":
                    sql += " AND 2 = case when (peso / (altura * altura)) BETWEEN 18.5 AND 24.9 THEN 2 end ";
                    break;
                case "3":
                    sql += " AND 3 = case when (peso / (altura * altura)) BETWEEN 25 AND 29.9 THEN 3 end ";
                    break;
                case "4":
                    sql += " AND 4 = case when (peso / (altura * altura)) BETWEEN 30 AND 34.9 THEN 4 end ";
                    break;
                case "5":
                    sql += " AND 5 = case when (peso / (altura * altura)) BETWEEN 35 AND 39.9 THEN 5 end ";
                    break;
                case "6":
                    sql += " AND 6 = case when (peso / (altura * altura)) >= 40 THEN 6 end ";
                    break;
            }
            return AcessoDB.GetDataTable(sql);
        }
        // Atleta chave por id e camisa //
        public bool GetAtletaChave(int id, int nrocamisa)
        {
            string sql = "SELECT Id, Nome, Apelido, Dtnascimento, Altura, Peso, Posicao, Nrocamisa ";
            sql += " FROM Atleta ";
            sql += " WHERE ID <> " + id;
            sql += " AND  Nrocamisa = " + nrocamisa;
            DataTable tabela = new DataTable();
            tabela = AcessoDB.GetDataTable(sql);

            if (tabela.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // Inclui //
        public void Incluir(Atleta oAtleta)
        {
            string dt = oAtleta.DtNascimento.ToString().Substring(6, oAtleta.DtNascimento.ToString().Length - 15) + "-";
            dt += oAtleta.DtNascimento.ToString().Substring(3, oAtleta.DtNascimento.ToString().Length - 17) + "-";
            dt += oAtleta.DtNascimento.ToString().Substring(0, oAtleta.DtNascimento.ToString().Length - 17);

            string sql = "INSERT INTO Atleta(Nome,Apelido,DtNascimento,Altura,Peso,Posicao,NroCamisa) ";
            sql += "values (";
            sql += "'" + oAtleta.Nome + "',";
            sql += "'" + oAtleta.Apelido + "',";
            sql += "'" + dt + "',";
            sql += oAtleta.Altura.ToString().Replace(",", ".") + ",";
            sql += oAtleta.Peso.ToString().Replace(",", ".") + ",";
            sql += "'" + oAtleta.Posicao + "',";
            sql += oAtleta.NroCamisa;
            sql += ")";

            AcessoDB.ExecuteNonQuery(sql);
        }
        // Altera //
        public void Alterar(Atleta oAtleta)
        {
            string dt = oAtleta.DtNascimento.ToString().Substring(6, oAtleta.DtNascimento.ToString().Length - 15) + "-";
            dt += oAtleta.DtNascimento.ToString().Substring(3, oAtleta.DtNascimento.ToString().Length - 17) + "-";
            dt += oAtleta.DtNascimento.ToString().Substring(0, oAtleta.DtNascimento.ToString().Length - 17);

            string sql = "UPDATE Atleta ";
            sql += " Set ";
            sql += " Nome  = '" + oAtleta.Nome + "',";
            sql += " Apelido = '" + oAtleta.Apelido + "',";
            sql += " DtNascimento = '" + dt + "',";
            sql += " Altura = " + oAtleta.Altura.ToString().Replace(",", ".") + ",";
            sql += " Peso = " + oAtleta.Peso.ToString().Replace(",", ".") + ",";
            sql += " Posicao = '" + oAtleta.Posicao + "',";
            sql += " NroCamisa = " + oAtleta.NroCamisa;
            sql += " Where Id = " + oAtleta.Id;

            AcessoDB.ExecuteNonQuery(sql);
        }
        // Delete por ID //
        public void Excluir(int id)
        {
            string sql = "DELETE FROM Atleta Where Id = " + id;
            AcessoDB.ExecuteNonQuery(sql);
        }
    }
}