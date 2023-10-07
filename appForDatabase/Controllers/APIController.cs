using appForDatabase.Model;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;

namespace appForDatabase.Controllers
{
    [ApiController]
    [Route("api")]
    public class APIController : ControllerBase
    {
        private readonly string StringDB = @"Server=containers-us-west-67.railway.app;
                        Port=7664;Database=railway;
                        User=root;
                        Password=NDCAVLFLa47wLwd4D8q3;";
        public MySqlConnection Conexao { get; set; }
        public string Sql { get; set; }
        public MySqlCommand Cmd { get; set; }
        public APIController()
        {
            Conexao = new MySqlConnection(StringDB);
        }

        [HttpPost("inserir-cliente")]
        public IActionResult inserirCliente([FromBody] Cliente cliente)
        {
            try
            {
                Conexao.Open();

                Sql = @"INSERT INTO clientes (cpf_cnpj, nome_razao_social, nome_fantasia, email, telefone, celular, cep, logradouro, complemento, numero, bairro, cidade, estado, pais) 
                                            VALUES (@cpf_cnpj, @nome_razao_social, @nome_fantasia, @email, @telefone, @celular, @cep, @logradouro, @complemento, @numero, @bairro, @cidade, @estado, @pais)";
                Cmd = new MySqlCommand(Sql, Conexao);
                Cmd.Parameters.AddWithValue("@cpf_cnpj", cliente.cpf_cnpj);
                Cmd.Parameters.AddWithValue("@nome_razao_social", cliente.nome_razao_social);
                Cmd.Parameters.AddWithValue("@nome_fantasia", cliente.nome_fantasia);
                Cmd.Parameters.AddWithValue("@email", cliente.email);
                Cmd.Parameters.AddWithValue("@telefone", cliente.telefone);
                Cmd.Parameters.AddWithValue("@celular", cliente.celular);
                Cmd.Parameters.AddWithValue("@cep", cliente.CEP);
                Cmd.Parameters.AddWithValue("@logradouro", cliente.logradouro);
                Cmd.Parameters.AddWithValue("@complemento", cliente.complemento);
                Cmd.Parameters.AddWithValue("@numero", cliente.numero);
                Cmd.Parameters.AddWithValue("@bairro", cliente.bairro);
                Cmd.Parameters.AddWithValue("@cidade", cliente.cidade);
                Cmd.Parameters.AddWithValue("@estado", cliente.estado);
                Cmd.Parameters.AddWithValue("@pais", cliente.pais);

                Cmd.ExecuteNonQuery();

                return Ok("Cliente cadastrado com sucesso");

            }
            catch (Exception ex)
            {
                return BadRequest("Cliente já cadastrado");
                //return BadRequest($"Erro ao inserir dados: {ex.Message}");
            }


        }
        [HttpGet("consulta-cliente")]
        public IActionResult consultaCliente([FromQuery] string cpf_cnpj)
        {
            try
            {
                Conexao.Open();
                Sql = "SELECT * FROM  clientes WHERE cpf_cnpj = @cpf_cnpj";
                Cmd = new MySqlCommand(Sql, Conexao);
                Cmd.Parameters.AddWithValue("@cpf_cnpj", cpf_cnpj);
                MySqlDataReader objeto = Cmd.ExecuteReader();

                if (objeto.Read())
                {
                    Cliente1 cliente = new Cliente1
                    {
                        CpfCnpj = objeto["cpf_cnpj"].ToString(),
                        Nome_razao_social = objeto["nome_razao_social"].ToString(),
                        Nome_fantasia = objeto["nome_fantasia"].ToString(),
                        Email = objeto["email"].ToString(),
                        Telefone = objeto["telefone"].ToString(),
                        Celular = objeto["celular"].ToString(),
                        Cep = objeto["cep"].ToString(),
                        Logradouro = objeto["logradouro"].ToString(),
                        Complemento = objeto["complemento"].ToString(),
                        Numero = objeto["numero"].ToString(),
                        Bairro = objeto["bairro"].ToString(),
                        Cidade = objeto["cidade"].ToString(),
                        Estado = objeto["estado"].ToString(),
                        Pais = objeto["pais"].ToString()
                    };

                    // Serialize o objeto Cliente1 em JSON
                    string jsonCliente = JsonConvert.SerializeObject(cliente);

                    return Ok(jsonCliente);
                }
                else
                {
                    return BadRequest($"CPF ou CNPJ não encontrado");
                }


            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao consultar dados: {ex.Message}");
            }


        }
        [HttpPost("atualiza-cliente")]
        public IActionResult atualizaCliente([FromBody] Cliente cliente)
        {
            try
            {
                Conexao.Open();

                Sql = @"UPDATE clientes SET nome_razao_social=@nome_razao_social, nome_fantasia=@nome_fantasia, email=@email, 
                                            telefone=@telefone, celular=@celular, cep=@cep, logradouro=@logradouro, 
                                            complemento=@complemento, numero=@numero, bairro=@bairro, cidade=@cidade, estado=@estado, pais=pais
                                            WHERE cpf_cnpj=@cpf_cnpj";
                Cmd = new MySqlCommand(Sql, Conexao);
                Cmd.Parameters.AddWithValue("@cpf_cnpj", cliente.cpf_cnpj);
                Cmd.Parameters.AddWithValue("@nome_razao_social", cliente.nome_razao_social);
                Cmd.Parameters.AddWithValue("@nome_fantasia", cliente.nome_fantasia);
                Cmd.Parameters.AddWithValue("@email", cliente.email);
                Cmd.Parameters.AddWithValue("@telefone", cliente.telefone);
                Cmd.Parameters.AddWithValue("@celular", cliente.celular);
                Cmd.Parameters.AddWithValue("@cep", cliente.CEP);
                Cmd.Parameters.AddWithValue("@logradouro", cliente.logradouro);
                Cmd.Parameters.AddWithValue("@complemento", cliente.complemento);
                Cmd.Parameters.AddWithValue("@numero", cliente.numero);
                Cmd.Parameters.AddWithValue("@bairro", cliente.bairro);
                Cmd.Parameters.AddWithValue("@cidade", cliente.cidade);
                Cmd.Parameters.AddWithValue("@estado", cliente.estado);
                Cmd.Parameters.AddWithValue("@pais", cliente.pais);

                Cmd.ExecuteNonQuery();

                return Ok("Cliente atualizado com sucesso");

            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao atualizar dados: {ex.Message}");
            }
        }
        [HttpDelete("delete-cliente")]
        public IActionResult deleteCliente([FromQuery] string cpf_cnpj)
        {
            try
            {
                Conexao.Open();
                Sql = "DELETE FROM clientes WHERE cpf_cnpj = @cpf_cnpj";
                Cmd = new MySqlCommand(Sql, Conexao);
                Cmd.Parameters.AddWithValue("@cpf_cnpj", cpf_cnpj);
                Cmd.ExecuteNonQuery();

                Conexao.Close();
                return Ok("Cliente excluído com sucesso");

            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao excluir cliente: {ex.Message}");
            }

        }
        [HttpGet("consulta-servicos")]
        public IActionResult consultaServicos()
        {
            try
            {
                Conexao.Open();
                Sql = "SELECT * FROM servicos";
                Cmd = new MySqlCommand(Sql, Conexao);
                MySqlDataReader objeto = Cmd.ExecuteReader();
                List<Servicos> servicos = new List<Servicos>();

                while (objeto.Read())
                {
                    Servicos servico = new Servicos
                    {
                        Id = int.Parse(objeto["id"].ToString()),
                        Servico = objeto["servico"].ToString()

                    };
                    servicos.Add(servico);

                }
                if (servicos.Count > 0)
                {
                    // Serialize o objeto Cliente1 em JSON
                    string jsonServicos = JsonConvert.SerializeObject(servicos);

                    return Ok(jsonServicos);

                }
                else
                {
                    return BadRequest($"Nenhum serviço cadastrado");
                }

            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao consultar dados: {ex.Message}");
            }


        }
        [HttpPost("insere-servicos")]
        public IActionResult insereServicos([FromBody] Servicos servico)
        {
            try
            {
                Conexao.Open();
                Sql = "INSERT INTO servicos (servico) VALUES (@servico)";
                Cmd = new MySqlCommand(Sql, Conexao);
                Cmd.Parameters.AddWithValue("@servico", servico.Servico);
                Cmd.ExecuteNonQuery();
                return Ok("Serviço cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao consultar dados: {ex.Message}");
            }


        }
    }
}