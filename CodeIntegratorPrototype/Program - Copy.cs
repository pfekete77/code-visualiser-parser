//// See https://aka.ms/new-console-template for more information
//using Microsoft.CodeAnalysis;
//using Microsoft.CodeAnalysis.MSBuild;

//Console.WriteLine("Hello, World!");

//string folder = @"..\..\..\..\"; // CodeIntegratorPrototype\";
//string[] directory_file_contents = Directory.GetFiles(folder);
//for (int i = 0; i< directory_file_contents.Length; i++)
//{
//    Console.WriteLine(directory_file_contents[i]);
//}
//string[] directory_folder_contents = Directory.GetDirectories(folder);
//for (int i = 0; i< directory_folder_contents.Length; i++ )
//{
//    Console.WriteLine(directory_folder_contents[i]);
//}

////const string pathToSolution = @"..\..\..\..\SampleToAnalyze\SampleToAnalyze.sln";
//const string pathToSolution = @"..\..\..\..\CodeIntegratorPrototype.sln";
//const string projectName = "SampleToAnalyze";

//MSBuildWorkspace workspace = MSBuildWorkspace.Create();

//Solution solutionToAnalyze = workspace.OpenSolutionAsync(pathToSolution).Result;

//Project sampleProjectToAnalyze = solutionToAnalyze.Projects
//                                        .Where((proj) => proj.Name == projectName)
//                                        .FirstOrDefault();


//Compilation sampleToAnalyzeCompilation = sampleProjectToAnalyze.GetCompilationAsync().Result;
