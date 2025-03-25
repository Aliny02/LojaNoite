using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using Microsoft.Data.SqlClient;
using Microsoft.Data;
using System.Data;
using Microsoft.Identity.Client;
using Dal;


namespace Dal
{
    public class ClientesDAL
    {
       public void Incluir(ClienteInformation cliente)
       {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Dados.StringConexao(); 
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "insere_cliente";

                SqlParameter pcodigo = new SqlParameter("@codigo", SqlDbType.Int);
                pcodigo.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(pcodigo);

                SqlParameter pnome = new SqlParameter("@nome", SqlDbType.NVarChar, 100);
                pnome.Value = cliente.Nome;
                cmd.Parameters.Add(pnome);

                SqlParameter pemail = new SqlParameter("@email", SqlDbType.NVarChar, 100);
                pnome.Value = cliente.Email;
                cmd.Parameters.Add(pemail);

                SqlParameter ptelefone = new SqlParameter("@telefone", SqlDbType.NVarChar, 100);
                pnome.Value = cliente.Telefone;
                cmd.Parameters.Add(ptelefone);



                cn.Open();
                cmd.ExecuteNonQuery();

                cliente.Codigo = (Int32)cmd.Parameters[0].Value;



               

            }
            catch (Exception ex)
            {

                throw new Exception("Servidor SQL Erro: " + ex.Message);
            }
            finally
            {
              cn.Close();  
            }
            
       }
       public void Alterar(ClienteInformation cliente)
       {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = "";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Altera_Cliente";

                SqlParameter pcodigo = new SqlParameter("Codigo", SqlDbType.Int);
                pcodigo.Value = cliente.Codigo;
                cmd.Parameters.Add(pcodigo);

                SqlParameter pnome = new SqlParameter("@nome", SqlDbType.Int);
                pcodigo.Value = cliente.Codigo;
                cmd.Parameters.Add(pnome);
                

                SqlParameter pemail = new SqlParameter("@email", SqlDbType.Int);
                pcodigo.Value = cliente.Codigo;
                cmd.Parameters.Add(pemail);
               

                SqlParameter ptelefone= new SqlParameter("@telefone", SqlDbType.Int);
                pcodigo.Value = cliente.Codigo;
                cmd.Parameters.Add(pnome);

                cn.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex) 
            {
                throw new Exception("erro no servidor sql" + ex.Message);
            }
            finally
            {
                cn.Close();

            }
           
        }
       public void Excluir(int codigo)
       {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Dados.StringConexao();
            }
       }
       

                
            
            
            
    }

}
