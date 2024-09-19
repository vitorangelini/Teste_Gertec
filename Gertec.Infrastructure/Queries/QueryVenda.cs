using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gertec.Infrastructure.Queries
{
    public class QueryVenda
    {
        public const string SELECT_OBTER_VENDA = @"SELECT 
		                                                    Id,
                                                            Vendedor,
                                                            PrecoMedio,
                                                            PrecoTotal,
                                                            DataCompra,
                                                            IdProduto,
                                                            IdCliente,
                                                            Quantidade
                                                    FROM 
		                                                    TBLVENDA
                                                    WHERE 
		                                                    Id = @idVenda";

        public const string SELECT_LISTAR_VENDA = @"select 
	                                                        Id,
	                                                        Vendedor,
	                                                        PrecoMedio,
	                                                        PrecoTotal,
	                                                        DataCompra,
	                                                        IdProduto,
	                                                        IdCliente,
	                                                        Quantidade
                                                        FROM 
	                                                        TBLVENDA
                                                        WHERE
	                                                        DATACOMPRA = @dataCompra";


        public const string INSERIR_VENDA = @"INSERT INTO tblVenda (Vendedor, IdProduto, IdCliente, Quantidade, PrecoMedio, PrecoTotal,DataCompra)
                                                            VALUES (@Vendedor, @IdProduto, @IdCliente, @Quantidade, @PrecoMedio, @PrecoTotal,NOW());
                                                            SELECT LAST_INSERT_ID()";
    }
}
