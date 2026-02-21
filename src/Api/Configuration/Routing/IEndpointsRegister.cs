namespace Api.Configuration.Routing;

public interface IEndpointsRegister
{
    static abstract void Map(IEndpointRouteBuilder app);
}
