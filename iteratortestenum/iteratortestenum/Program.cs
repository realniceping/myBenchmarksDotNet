using System.Runtime.InteropServices;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

//hello gays 
//today i will show you some missconception in c#
//ints conception is iterators

//let's create some funciton that will return iterator object 

/*var GeneratorInstance = generator(1000);
var generatorList = GeneratorInstance.ToList();
generatorList[20] = 112;


IEnumerable<int> generator(int n )
{
    for (int i = 0; i < n; i++)
    {
        yield return i * i;
    }
}*/
BenchmarkRunner.Run<Benchy>();

[MemoryDiagnoser(true)]
[SimpleJob(RuntimeMoniker.Net60)]
[SimpleJob(RuntimeMoniker.Net70)]
public class Benchy
{
    
    

    //[Benchmark]
    private IEnumerable<int> CreateQubeNumberSeqenceEnumerable()
    {
        for (int i = 1; i <= 100; i++)
        {
            yield return i * i * i;
        }

    }

    [Benchmark]
    public void CreateQubeNumberSequenceAsIterTest()
    {
        var generator = CreateQubeNumberSeqenceEnumerable();
    }

    [Benchmark]
    public void CreateQubeNumberSequenceAsList()
    {
        var list = new List<int>();
        for (int i = 1; i <= 100; i++)
        {
            list.Add(i*i*i);
        }
    }

    [Benchmark]
    public void CreateQubeNumberSequenceAsListByIEnumerableToListMillion()
    {
        var list = CreateQubeNumberSeqenceEnumerableMillion().ToList();
    }

    [Benchmark]
    public void CreateAndIterBySequenceIterator()
    {
        foreach (var i in CreateQubeNumberSeqenceEnumerable())          
        {
            var j = i;
        }
    }

    private IEnumerable<int> CreateQubeNumberSeqenceEnumerableMillion()
    {
        for (int i = 1; i <= 1000000; i++)
        {
            yield return i * i * i;
        }

    }
    
    [Benchmark]
    public void CreateAndIterBySequenceIteratorMiillion()
    {
        foreach (var i in CreateQubeNumberSeqenceEnumerableMillion())          
        {
            var j = i;
        }
    }
    
    [Benchmark]
    public void CreateAndIterBySequenceList()
    {
        var list = new List<int>();
        for (int i = 1; i <= 100; i++)
        {
            list.Add(i*i*i);
        }

        foreach (var i in list)
        {
            var j = i;
        }
    }

    [Benchmark]
    public void CreateAndIterBySequenceListMillion()
    {
        var list = new List<int>();
        for (int i = 1; i <= 1000000; i++)
        {
            list.Add(i*i*i);
        }

        foreach (var i in list)
        {
            var j = i;
        }
    }
    
    [Benchmark]
    public void CreateAndIterBySequenceListAsSpan()
    {   
        var list = new List<int>();
        for (int i = 1; i <= 100; i++)
        {
            list.Add(i*i*i);
        }

        foreach (var item in CollectionsMarshal.AsSpan(list))
        {
            
        }

    }
    

}
