using CRS.Entity.Generics;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS.Entity.Models
{
    public class Warehouse : BaseEntity
    {
        // Database fields
        [Column("WarehouseId")]
        [Key]
        public override int Id { get; set; }

        // Grade records
        public double PerviousCGPA { get; set; }
        public double NextCGPA { get; set; }

        // List of subjects for CS Students
        public bool? BusinessMath1 { get; set; }
        public bool? BasicsInNaturalScience { get; set; }
        public bool? EnglishReadingSkillsAndPublicSpeaking { get; set; }
        public bool? BusinessMath2 { get; set; }
        public bool? EnglishWritingSkillsAndCommunication { get; set; }
        public bool? PrinciplesOfAccounting { get; set; }
        public bool? PrinciplesOfManagement { get; set; }
        public bool? ManagementInformationSystem { get; set; }
        public bool? BusinessCommunications { get; set; }
        public bool? PrinciplesOfEconomics { get; set; }
        public bool? PrinciplesOfMarketing { get; set; }
        public bool? BusinessStatistics { get; set; }
        public bool? ComputerUtilizationInBusiness { get; set; }
        public bool? DecisionSupportSystem { get; set; }
        public bool? GlobalInformationTechnologyManagement { get; set; }
        public bool? DifferentialCalculusAndCoordinateGeometry { get; set; }
        public bool? Physics1 { get; set; }
        public bool? Physics1Lab { get; set; }
        public bool? IntegralCalculusAndOrdinaryDifferentialEquation { get; set; }
        public bool? Physics2 { get; set; }
        public bool? Physics2Lab { get; set; }
        public bool? ComplexVariableLaplaceAndZTransformation { get; set; }
        public bool? ElectricalCircuits1 { get; set; }
        public bool? ElectricalCircuits1Lab { get; set; }
        public bool? ElectricalCircuits2 { get; set; }
        public bool? ElectricalCircuits2Lab { get; set; }
        public bool? ElectronicDevicesLab { get; set; }
        public bool? ElectronicDevices { get; set; }
        public bool? ComputerAidedDesignAndDrafting { get; set; }
        public bool? MatricesVectorsFourierAnalysis { get; set; }
        public bool? DigitalLogicDesign { get; set; }
        public bool? DigitalLogicDesignLab { get; set; }
        public bool? MathematicalMethodsOfEngineering { get; set; }
        public bool? StatisticsAndProbability { get; set; }
        public bool? DigitalElectronics { get; set; }
        public bool? DigitalElectronicsLab { get; set; }
        public bool? EngineeringManagement { get; set; }
        public bool? ElectronicsShop { get; set; }
        public bool? MicroprocessorAndIOSystem { get; set; }
        public bool? EngineeringEthics { get; set; }
        public bool? DigitalSignalProcessing { get; set; }
        public bool? NetworkResourceManagement { get; set; }
        public bool? VHDLModelingAndLogicSynthesis { get; set; }
        public bool? VLSICircuitDesign { get; set; }
        public bool? SignalsAndLinearSystem { get; set; }
        public bool? RoboticsEngineering { get; set; }
        public bool? LinearAlgebraComplexVariableLaplaceTransformationAndFourierAnalysis { get; set; }
        public bool? IntroductionToElectricalEngineering { get; set; }
        public bool? IntroductionToElectricalEngineeringLab { get; set; }
        public bool? ProgrammingLanguage1 { get; set; }
        public bool? ComputerFundamentals { get; set; }
        public bool? DiscreteMathematics { get; set; }
        public bool? ProgrammingLanguage2 { get; set; }
        public bool? DataStructure { get; set; }
        public bool? IntroductionToDatabase { get; set; }
        public bool? ComputerOrganizationAndArchitecture { get; set; }
        public bool? Algorithms { get; set; }
        public bool? ObjectOrientedProgramming1 { get; set; }
        public bool? OperatingSystems { get; set; }
        public bool? ObjectOrientedAnalysisAndDesign { get; set; }
        public bool? ObjectOrientedProgramming2 { get; set; }
        public bool? SoftwareEngineering { get; set; }
        public bool? ComputerNetworks { get; set; }
        public bool? TheoryOfComputation { get; set; }
        public bool? CompilerDesign { get; set; }
        public bool? CSMath { get; set; }
        public bool? WebTechnologies { get; set; }
        public bool? AdvancedComputerNetworks { get; set; }
        public bool? ArtificialIntelligenceAndExpertSystems { get; set; }
        public bool? ResearchMethodology { get; set; }
        public bool? Thesis { get; set; }
        public bool? Internship { get; set; }
        public bool? AdvanceDatabaseManagementSystem { get; set; }
        public bool? BasicGraphTheory { get; set; }
        public bool? MultimediaSystems { get; set; }
        public bool? DataWarehousingAndDataMining { get; set; }
        public bool? SoftwareDevelopmentProjectManagement { get; set; }
        public bool? FormalMethodsofSoftwareEngineering { get; set; }
        public bool? HumanComputerInteraction { get; set; }
        public bool? SoftwareRequirementsEngineering { get; set; }
        public bool? EmbeddedTechnologies { get; set; }
        public bool? AdvancedTopicsInProgramming1 { get; set; }
        public bool? AdvancedTopicsInProgramming2 { get; set; }
        public bool? AdvancedTopicsInProgramming3 { get; set; }
        public bool? ComputerVisionAndPatternRecognition { get; set; }
        public bool? LinearProgramming { get; set; }
        public bool? NetworkSecurity { get; set; }
        public bool? EmbeddedSystemSoftware { get; set; }
        public bool? SoftwareQualityAndTesting { get; set; }
        public bool? AdvancedOperatingSystem { get; set; }
        public bool? ComputerGraphics { get; set; }
        public bool? SimulationAndModelling { get; set; }
        public bool? EGovernance { get; set; }
        public bool? EnterpriseResourcePlanning { get; set; }
        public bool? ComputerAndInformationEthics { get; set; }
        public bool? SoftwareProject1 { get; set; }
        public bool? SoftwareProject2 { get; set; }
        public bool? InternetSecurity { get; set; }

    }
}
