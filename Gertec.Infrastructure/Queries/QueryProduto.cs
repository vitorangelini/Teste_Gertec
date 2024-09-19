using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gertec.Infrastructure.Queries
{
    public  class QueryProduto
    {
        public const string SELECT_OBTER_PRD = @"select 
		                                                Id as IdProduto,
                                                        Descricao,
                                                        Valor,
                                                        PartNumber,
                                                        DataCriacao,
                                                        Quantidade,
                                                        DataAtualizacao,
                                                        Ativo
                                                from 
	                                                  tblproduto
                                                where
                                                      Ativo=1
	                                                  and PartNumber= @PartNumber";

        public const string SELECT_OBTER_PRD_ID = @"select 
		                                                Id as IdProduto,
                                                        Descricao,
                                                        Valor,
                                                        PartNumber,
                                                        DataCriacao,
                                                        Quantidade,
                                                        DataAtualizacao,
                                                        Ativo
                                                from 
	                                                  tblproduto
                                                where
	                                                  Id= @IdProduto";
        

        public const string INSERIR_PRODUTO = @"INSERT INTO TBLPRODUTO (Descricao, Valor, PartNumber, Quantidade, DataCriacao, DataAtualizacao, Ativo)
                                                       VALUES (@Descricao, @Valor, @PartNumber, @Quantidade, NOW(), NOW(), 1);
                                                       SELECT LAST_INSERT_ID()";

        public const string ATUALIZAR_PRODUTO = @"UPDATE tblProduto
                                                    SET Descricao = @Descricao,
                                                        Valor = @Valor,
                                                        PartNumber = @PartNumber,
                                                        Quantidade = @Quantidade,
                                                        Ativo = @Ativo,
                                                        DataCriacao =NOW(),
                                                        DataAtualizacao = NOW()
                                                    WHERE Id = @IdProduto";

        public const string DELETAR_PRODUTO = @"UPDATE tblProduto SET ATIVO =0 WHERE Id = @idProduto";

        public const string UPDATE_QUANTIDADE = @"UPDATE tblProduto SET Quantidade =(Quantidade  -@Quantidade) WHERE Id=@IdProduto";
    }
}
