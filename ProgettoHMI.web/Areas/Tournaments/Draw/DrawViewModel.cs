namespace ProgettoHMI.web.Areas.Tournaments.Draw
{
    public class DrawViewModel
    {

        public string ToJson()
        {
            return Infrastructure.JsonSerializer.ToJsonCamelCase(this);
        }
    }
}
