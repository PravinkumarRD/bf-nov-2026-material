namespace InterfaceExamples;

internal class Science : IScience
{
    void IPhysics.ApplyGravity()
    {
        throw new NotImplementedException();
    }

    void IChemistry.ConductExperiment()
    {
        throw new NotImplementedException();
    }

    void IBiology.ObserveSpecimens()
    {
        throw new NotImplementedException();
    }
}
