using AutoMapper;
using Gertec.Application.ViewModels.Requests.Cliente;
using Gertec.Application.ViewModels.Requests.Produto;
using Gertec.Application.ViewModels.Requests.Venda;
using Gertec.Application.ViewModels.Responses.Cliente;
using Gertec.Application.ViewModels.Responses.Produto;
using Gertec.Application.ViewModels.Responses.Venda;
using Gertec.Domain.Entites.Cliente;
using Gertec.Domain.Entites.Produto;
using Gertec.Domain.Entites.Venda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gertec.Application.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            AllowNullCollections = true;
            AllowNullDestinationValues = true;

            this.CreateMap<SalvarClienteRequest, ClienteEntity>().ReverseMap();
            this.CreateMap<EditarClienteRequest, ClienteEntity>().ReverseMap();
            this.CreateMap<EnderecoRequest, EnderecoEntity>().ReverseMap();
            this.CreateMap<EditarProdutoRequest, EditarProdutoEntity>().ReverseMap();
            this.CreateMap<SalvarProdutoRequest, SalvarProdutoEntity>().ReverseMap();
            this.CreateMap<ResumoVendaRequest, VendaEntity>().ReverseMap();
            this.CreateMap<SalvarVendaRequest, VendaEntity>().ReverseMap();
            
            this.CreateMap<ClienteEntity, ClienteResponse>().ReverseMap();
            this.CreateMap<EnderecoEntity, EnderecoResponse>().ReverseMap();
            this.CreateMap<ProdutoEntity, ProdutoResponse>().ReverseMap();
            this.CreateMap<VendaEntity, VendaResponse>().ReverseMap();
        }
    }
}
