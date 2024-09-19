namespace FSH.WebApi.Application.Catalog.ReportType;

public class UpdateReportTypeRequestValidator : CustomValidator<UpdateReportTypeRequest>
{
    public UpdateReportTypeRequestValidator(IReadRepository<FSH.WebApi.Domain.Catalog.ReportTypes> reportTypeRepo, IStringLocalizer<UpdateReportTypeRequestValidator> T)
    {
        RuleFor(p => p.ReportName)
            .NotEmpty()
            .MaximumLength(75)
            .MustAsync(async (reportType, name, ct) =>
                    await reportTypeRepo.FirstOrDefaultAsync(new ReportTypeByNameSpec(name), ct)
                        is not FSH.WebApi.Domain.Catalog.ReportTypes existingReportType || existingReportType.Id == reportType.Id)
                .WithMessage((_, name) => T["ReportType {0} already Exists.", name]);
    }
}