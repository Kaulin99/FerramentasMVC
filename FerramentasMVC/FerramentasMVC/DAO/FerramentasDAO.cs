using FerramentasMVC.Models;
using System.Data;
using System.Data.SqlClient;


namespace FerramentasMVC.DAO
{
    public class FerramentasDAO 
    {
        private SqlParameter[] EnviaParametros(FerramentasViewModel f)
        {
            SqlParameter[] envia = new SqlParameter[3];
            envia[0] = new SqlParameter("Id", f.Id);
            envia[1] = new SqlParameter("descricao", f.descricao);
            envia[2] = new SqlParameter("FabricanteId", f.FabricanteId);

            return envia;
        }

        private FerramentasViewModel RecebeParametros(DataRow recebe)
        {
            FerramentasViewModel f = new FerramentasViewModel();
            f.Id = Convert.ToInt32(recebe["Id"]);
            f.descricao = Convert.ToString(recebe["Description"]);
            f.FabricanteId = Convert.ToInt32(recebe["FabricanteId"]);

            return f;
        }

        public List<FerramentasViewModel> CriaLista()
        {
            List<FerramentasViewModel> lista = new List<FerramentasViewModel>();
            SqlParameter[] parametro = new SqlParameter[]
                {
                    new SqlParameter("Tabela","ferramentas")
                };


            DataTable tabela = HelperDAO.ExecutaProcSelect("spListagem",parametro);
            
            foreach (DataRow row in tabela.Rows)
            {
                lista.Add(RecebeParametros(row));
            }
            return lista;
        }
        
        public void Inserir(FerramentasDAO f)
        {
            HelperDAO.ExecutaProc("",null);
        }
    }
}
