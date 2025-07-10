using PedidosApi.Models;
using PedidosApi.Models.DTOs;

namespace PedidosApi.Mappings;

using AutoMapper;
using PedidosApi.Models;
using PedidosApi.Models.DTOs;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //Cliente
        CreateMap<Cliente, ClienteDto>()
            .ForMember(dest => dest.Pedidos, opt =>
                opt.MapFrom(src => src.Pedidos));
        CreateMap<ClienteCreateDto, Cliente>();
        
        //PedidoResumoDto - usado para relacionar Cliente - Pedido
        CreateMap<Pedido, PedidoResumoDto>();
        
        //Produto
        CreateMap<Produto, ProdutoDto>();
        CreateMap<ProdutoCreateDto, Produto>();
        
        //Pedido
        CreateMap<Pedido, PedidoDto>()
            .ForMember(dest => dest.ProdutosIds, opt =>
                opt.MapFrom(src => src.Itens.Select(pp => pp.ProdutoId)));
        
        CreateMap<PedidoCreateDto, Pedido>()
            .ForMember(dest => dest.Itens, opt =>
                opt.Ignore());
        
        CreateMap<PedidoUpdateDto, Pedido>()
            .ForMember(dest => dest.Itens, opt =>
                opt.Ignore());
    }
    
}