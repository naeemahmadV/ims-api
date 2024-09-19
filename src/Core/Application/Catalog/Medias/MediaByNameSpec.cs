
namespace FSH.WebApi.Application.Catalog.Medias;
public class MediaByNameSpec : Specification<Media>, ISingleResultSpecification
{
    public MediaByNameSpec(string name) => Query.Where(p => p.MediaName == name);
}
