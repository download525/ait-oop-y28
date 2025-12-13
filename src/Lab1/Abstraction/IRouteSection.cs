using Itmo.ObjectOrientedProgramming.Lab1.Entity;
using Itmo.ObjectOrientedProgramming.Lab1.Routing.SectionsTypes;

namespace Itmo.ObjectOrientedProgramming.Lab1.Abstraction;

public interface IRouteSection
{
     SectionPassResult Pass(Train train);
}