using AutoMapper;
using Domain.Entities;

namespace Domain.Dtos.UserConnectionDtos;

[AutoMap(typeof(UserConnection), ReverseMap = true)]
public class ListUserConnectionDto
{
    /*
    Escrever método customizado de listar
    no repositório do UserConnection, ele
    deverá procurar pelo "UserId" nas duas
    colunas da tabela que possuem Id de usuário
    (tanto ConnectionRequester quanto ConnectionAddressee)    
    */
    
    public int UserId { get; set; }
}
