using System;
using Npgsql;

public class FuncionarioDAO
{
    private readonly NpgsqlConnection _conexao;

    public FuncionarioDAO(NpgsqlConnection conexao)
    {
        _conexao = conexao;
    }

    // 1. Criar funcionário
    public void CriarFuncionario(string nome, string cargo, decimal salario)
    {
        string query = "INSERT INTO funcionarios (nome, cargo, salario) VALUES (@nome, @cargo, @salario)";
        using (var cmd = new NpgsqlCommand(query, _conexao))
        {
            cmd.Parameters.AddWithValue("nome", nome);
            cmd.Parameters.AddWithValue("cargo", cargo);
            cmd.Parameters.AddWithValue("salario", salario);
            cmd.ExecuteNonQuery();
        }
    }

    // 2. Ler funcionário por ID
    public void BuscarFuncionarioPorId(int id)
    {
        string query = "SELECT * FROM funcionarios WHERE id = @id";
        using (var cmd = new NpgsqlCommand(query, _conexao))
        {
            cmd.Parameters.AddWithValue("id", id);
            using (var reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["id"]}, Nome: {reader["nome"]}, Cargo: {reader["cargo"]}, Salário: {reader["salario"]}");
                }
                else
                {
                    Console.WriteLine("Funcionário não encontrado.");
                }
            }
        }
    }

    // 3. Atualizar salário do funcionário
    public void AtualizarSalarioFuncionario(int id, decimal novoSalario)
    {
        string query = "UPDATE funcionarios SET salario = @salario WHERE id = @id";
        using (var cmd = new NpgsqlCommand(query, _conexao))
        {
            cmd.Parameters.AddWithValue("salario", novoSalario);
            cmd.Parameters.AddWithValue("id", id);
            int linhasAfetadas = cmd.ExecuteNonQuery();
            Console.WriteLine(linhasAfetadas > 0 ? "Salário atualizado com sucesso." : "Funcionário não encontrado.");
        }
    }
}
