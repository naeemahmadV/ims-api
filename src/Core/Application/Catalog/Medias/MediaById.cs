
namespace FSH.WebApi.Application.Catalog.Medias;
public class MediaById : Specification<Media, MediaDto>, ISingleResultSpecification
{
    public MediaById(Guid id) =>
      Query.Where(p => p.Id == id);
}
