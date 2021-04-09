using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace Polizia_Ilaria
{
    static class Layer
    {
        static string _connectionString = ConfigurationManager.ConnectionStrings["Polizia"].ConnectionString;

        //METODO CHE MI RITORNA LA LISTA DI TUTTI GLI AGENTI COI RELATIVI DATI 
        static public List<Agente> MostraAgenti(int idAgente)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("Select CodiceFiscale + '-' + NomeCognome '-' AnniServizio 'anni di servizio' from AgenteDiPolizia", conn))
            {
                List<Agente> agenti = new List<Agente>();

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                    agenti.Add(new Agente(
                      (int)reader["IdAgente"],
                      reader["Nome"].ToString(),
                      reader["Cognome"].ToString(),
                      reader["CodiceFiscale"].ToString(),
                      (int)reader["AnniServizio"],
                      (DateTime)reader["DataNascita"]));
                return agenti;
            }
        }

        //METODO CHE MI RITORNA GLI AGENTI PER SPECIFICA AREA
        public static List<AgenteArea> MostraAgentiDellArea(int idAgente, int codiceArea)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("Select AgenteDiPolizia.IdAgente, AreaMetropolitana.CodiceArea from AgenteDiPolizia inner join AreaMetropolitana on AreaMetropolitana.IdAgente=AgenteDiPolizia.IdAgente", conn))
            {
                List<AgenteArea> agentiArea = new List<AgenteArea>();

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                    agentiArea.Add(new AgenteArea((int)reader["IdAgente"], (int)reader["CodiceArea"]));


                return agentiArea;
            }
        }
        //METODO CHE RITORNA LA LISTA AGENTI CON DATI ANNI DI SERVIZIO
        static public List<Agente> MostraAgentiServizio(int idAgente, int anniServizio)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("Select CodiceFiscale + '-' + NomeCognome '-' AnniServizio 'anni di servizio' from AgenteDiPolizia where AnniServizio >= @anniServizio", conn))
            {
                List<Agente> agentiAnniServizio = new List<Agente>();

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                    agentiAnniServizio.Add(new Agente(
                        (int)reader["IdAgente"],
                        reader["Nome"].ToString(),
                        reader["Cognome"].ToString(),
                        reader["CodiceFiscale"].ToString(),
                       (int)reader["AnniServizio"],
                       (DateTime)reader["DataNascita"]));


                return agentiAnniServizio;
            }
        }

        //METODO PER INSERIRE UN AGENTE IN MODALITA' DISCONNESSA
        public static Agente InserisciAgente(string nome, string cognome, string codiceFiscale, DateTime dataNascita, int anniServizio)
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlDataAdapter da = new SqlDataAdapter("Select * from AgenteDiPolizia", conn))

            {

                da.Fill(ds, "AgenteDiPolizia");

                DataTable tabellaAgenti = ds.Tables["AgenteDiPolizia"];

                tabellaAgenti.Rows.Add(0, nome, cognome, codiceFiscale, anniServizio, dataNascita);


                Console.WriteLine();

                SqlCommandBuilder cb = new SqlCommandBuilder(da); //genera in automatico i command di update, delete e insert necessari


                da.Update(tabellaAgenti);
                SqlCommand cmd = new SqlCommand("Select @@identity", conn);
                int idAgente = (int)(decimal)cmd.ExecuteScalar();

                return new Agente(idAgente, nome, cognome, codiceFiscale, anniServizio, dataNascita);


            }
        }
    }
}
