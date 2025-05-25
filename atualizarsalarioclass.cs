public void AtualizarSalarioFuncionario(NpgsqlConnection conexao, int id, decimal novoSalario)
{
    string query = "UPDATE funcionarios SET salario = @salario WHERE id = @id";
    using (var cmd = new NpgsqlCommand(query, conexao))
    {
        cmd.Parameters.AddWithValue("salario", novoSalario);
        cmd.Parameters.AddWithValue("id", id);
        int linhasAfetadas = cmd.ExecuteNonQuery();
        Console.WriteLine(linhasAfetadas > 0 ? "Salário atualizado com sucesso." : "Funcionário não encontrado.");
    }
}
