using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gertec.Infrastructure.Queries
{
    public class QueryCliente
    {
        public const string SELECT_OBTER_CLIENTE = @"SELECT 
	                                                        cl.Id,
                                                            cl.Nome,
                                                            cl.Cpf,
                                                            cl.Idade,
                                                            cl.Telefone,
                                                            ed.Pais as 'Pais',
                                                            ed.Estado as 'Estado',
                                                            ed.Cidade as 'Cidade',
                                                            ed.Bairro as 'Bairro',
                                                            ed.Numero as 'Numero',
                                                            ed.Rua as 'Rua',
                                                            ed.Complemento as 'Complemento',
                                                            cl.Ativo
                                                        FROM 
		                                                        TBLCLIENTE cl Inner Join tblEndereco ed
					                                                          on cl.IdEndereco=ed.Id
                                                        WHERE 
                                                                cl.Ativo= 1    
		                                                        and cl.Cpf = @cpf";
   

        public const string INSERIR_ENDERECO = @"INSERT INTO TBLENDERECO (Pais,Estado, Cidade, Bairro, Rua, Numero, Complemento)
                                                                  VALUES (@Pais,@Estado, @Cidade, @Bairro, @Rua, @Numero, @Complemento);
                                                                SELECT LAST_INSERT_ID()";

        public const string INSERIR_CLIENTE = @"INSERT INTO TBLCLIENTE (Nome, Cpf, Idade, Telefone, IdEndereco, Ativo)
                                                                VALUES (@Nome, @Cpf, @Idade, @Telefone,@IdEndereco,1);
                                                                SELECT LAST_INSERT_ID()";

        public const string ATUALIZAR_ENDERECO = @"UPDATE TBLENDERECO
                                                    SET 
                                                        Pais = @Pais,
                                                        Estado = @Estado,
                                                        Cidade = @Cidade,
                                                        Bairro = @Bairro,
                                                        Rua = @Rua,
                                                        Numero = @Numero,
                                                        Complemento = @Complemento
                                                    WHERE Id = @IdEndereco";

        public const string ATUALIZAR_CLIENTE = @"UPDATE TBLCLIENTE
                                                    SET 
                                                        Nome = @Nome,
                                                        Cpf = @Cpf,
                                                        Idade = @Idade,
                                                        Telefone = @Telefone,
                                                        Ativo = @Ativo
                                                    WHERE Id = @IdCliente";

        public const string SELECT_ID_ENDERECO= @"SELECT Id FROM TBLENDERECO WHERE Id = (SELECT IdEndereco FROM TBLCLIENTE WHERE ativo =1 and Cpf = @Cpf)";   

        public const string DELETAR_CLIENTE = @"UPDATE tblCliente SET ATIVO = 0 WHERE Id = @IdCliente";
    }
}
