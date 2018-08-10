using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS.Entity.SupportModels
{
    // This model is used when predicting
    public class WarehousePredict
    {
        public double PerviousCGPA { get; set; }

        // List of subjects for CS Students
        public int? BusinessMath1 { get; set; } = 0;
        public int? BasicsInNaturalScience { get; set; } = 0;
        public int? EnglishReadingSkillsAndPublicSpeaking { get; set; } = 0;
        public int? BusinessMath2 { get; set; } = 0;
        public int? EnglishWritingSkillsAndCommunication { get; set; } = 0;
        public int? PrinciplesOfAccounting { get; set; } = 0;
        public int? PrinciplesOfManagement { get; set; } = 0;
        public int? ManagementInformationSystem { get; set; } = 0;
        public int? BusinessCommunications { get; set; } = 0;
        public int? PrinciplesOfEconomics { get; set; } = 0;
        public int? PrinciplesOfMarketing { get; set; } = 0;
        public int? BusinessStatistics { get; set; } = 0;
        public int? ComputerUtilizationInBusiness { get; set; } = 0;
        public int? DecisionSupportSystem { get; set; } = 0;
        public int? GlobalInformationTechnologyManagement { get; set; } = 0;
        public int? DifferentialCalculusAndCoordinateGeometry { get; set; } = 0;
        public int? Physics1 { get; set; } = 0;
        public int? Physics1Lab { get; set; } = 0;
        public int? IntegralCalculusAndOrdinaryDifferentialEquation { get; set; } = 0;
        public int? Physics2 { get; set; } = 0;
        public int? Physics2Lab { get; set; } = 0;
        public int? ComplexVariableLaplaceAndZTransformation { get; set; } = 0;
        public int? ElectricalCircuits1 { get; set; } = 0;
        public int? ElectricalCircuits1Lab { get; set; } = 0;
        public int? ElectricalCircuits2 { get; set; } = 0;
        public int? ElectricalCircuits2Lab { get; set; } = 0;
        public int? ElectronicDevicesLab { get; set; } = 0;
        public int? ElectronicDevices { get; set; } = 0;
        public int? ComputerAidedDesignAndDrafting { get; set; } = 0;
        public int? MatricesVectorsFourierAnalysis { get; set; } = 0;
        public int? DigitalLogicDesign { get; set; } = 0;
        public int? DigitalLogicDesignLab { get; set; } = 0;
        public int? MathematicalMethodsOfEngineering { get; set; } = 0;
        public int? StatisticsAndProbability { get; set; } = 0;
        public int? DigitalElectronics { get; set; } = 0;
        public int? DigitalElectronicsLab { get; set; } = 0;
        public int? EngineeringManagement { get; set; } = 0;
        public int? ElectronicsShop { get; set; } = 0;
        public int? MicroprocessorAndIOSystem { get; set; } = 0;
        public int? EngineeringEthics { get; set; } = 0;
        public int? DigitalSignalProcessing { get; set; } = 0;
        public int? NetworkResourceManagement { get; set; } = 0;
        public int? VHDLModelingAndLogicSynthesis { get; set; } = 0;
        public int? VLSICircuitDesign { get; set; } = 0;
        public int? SignalsAndLinearSystem { get; set; } = 0;
        public int? RoboticsEngineering { get; set; } = 0;
        public int? LinearAlgebraComplexVariableLaplaceTransformationAndFourierAnalysis { get; set; } = 0;
        public int? IntroductionToElectricalEngineering { get; set; } = 0;
        public int? IntroductionToElectricalEngineeringLab { get; set; } = 0;
        public int? ProgrammingLanguage1 { get; set; } = 0;
        public int? ComputerFundamentals { get; set; } = 0;
        public int? DiscreteMathematics { get; set; } = 0;
        public int? ProgrammingLanguage2 { get; set; } = 0;
        public int? DataStructure { get; set; } = 0;
        public int? IntroductionToDatabase { get; set; } = 0;
        public int? ComputerOrganizationAndArchitecture { get; set; } = 0;
        public int? Algorithms { get; set; } = 0;
        public int? ObjectOrientedProgramming1 { get; set; } = 0;
        public int? OperatingSystems { get; set; } = 0;
        public int? ObjectOrientedAnalysisAndDesign { get; set; } = 0;
        public int? ObjectOrientedProgramming2 { get; set; } = 0;
        public int? SoftwareEngineering { get; set; } = 0;
        public int? ComputerNetworks { get; set; } = 0;
        public int? TheoryOfComputation { get; set; } = 0;
        public int? CompilerDesign { get; set; } = 0;
        public int? CSMath { get; set; } = 0;
        public int? WebTechnologies { get; set; } = 0;
        public int? AdvancedComputerNetworks { get; set; } = 0;
        public int? ArtificialIntelligenceAndExpertSystems { get; set; } = 0;
        public int? ResearchMethodology { get; set; } = 0;
        public int? Thesis { get; set; } = 0;
        public int? Internship { get; set; } = 0;
        public int? AdvanceDatabaseManagementSystem { get; set; } = 0;
        public int? BasicGraphTheory { get; set; } = 0;
        public int? MultimediaSystems { get; set; } = 0;
        public int? DataWarehousingAndDataMining { get; set; } = 0;
        public int? SoftwareDevelopmentProjectManagement { get; set; } = 0;
        public int? FormalMethodsofSoftwareEngineering { get; set; } = 0;
        public int? HumanComputerInteraction { get; set; } = 0;
        public int? SoftwareRequirementsEngineering { get; set; } = 0;
        public int? EmbeddedTechnologies { get; set; } = 0;
        public int? AdvancedTopicsInProgramming1 { get; set; } = 0;
        public int? AdvancedTopicsInProgramming2 { get; set; } = 0;
        public int? AdvancedTopicsInProgramming3 { get; set; } = 0;
        public int? ComputerVisionAndPatternRecognition { get; set; } = 0;
        public int? LinearProgramming { get; set; } = 0;
        public int? NetworkSecurity { get; set; } = 0;
        public int? EmbeddedSystemSoftware { get; set; } = 0;
        public int? SoftwareQualityAndTesting { get; set; } = 0;
        public int? AdvancedOperatingSystem { get; set; } = 0;
        public int? ComputerGraphics { get; set; } = 0;
        public int? SimulationAndModelling { get; set; } = 0;
        public int? EGovernance { get; set; } = 0;
        public int? EnterpriseResourcePlanning { get; set; } = 0;
        public int? ComputerAndInformationEthics { get; set; } = 0;
        public int? SoftwareProject1 { get; set; } = 0;
        public int? SoftwareProject2 { get; set; } = 0;
        public int? InternetSecurity { get; set; } = 0;
    }
}
