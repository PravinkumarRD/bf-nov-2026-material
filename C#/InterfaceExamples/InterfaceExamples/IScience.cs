namespace InterfaceExamples;

internal interface IScience : IPhysics, IChemistry, IBiology
{
    public string ConductResearch()
    {
        return "Conducting research in physics, chemistry, and biology.";
    }
}
