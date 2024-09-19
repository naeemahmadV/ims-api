
namespace FSH.WebApi.Application.Catalog.SubSkill;
public class SubSkillDto : IDto
{
    public Guid Id { get; set; }
    public string SubSkillName { get; set; } = default!;
    public Guid SkillId { get; set; }
    public string SkillName { get; set; }
}
