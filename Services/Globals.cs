namespace Services
{
    using System;
    
    public static class Globals
    {
        public static bool IsWindows = false;
        public static bool IsLinux = false;
        public static bool IsMAC = false;
        public static string Browser = "";
        public static int ReadyModeTimeout = 0;
        public static bool ModeChangeFlag;
        public static int VascularValue = 0;
        public static int Mode40mmValue = 0;
        public static int StandardValue = 0;

        public static bool IsConsoleLoaded = false;
        public static bool IsWarmupDone = false;
        public static bool IsSysMainLoaded = false;
        public static bool IsTechModeLoginLoaded = false;
        public static bool IsThreshSetLoaded = false;
        public static bool IsErrorThreshSet = false;

        public static string StrLongOrShortYAG { get; set; }
        public static double PFNcapYAG { get; set; }
        public static int P_SupplyYAG { get; set; }
        public static int TempSetYAG { get; set; }
        public static bool P_MeterFlagYAG { get; set; }
        public static bool SimpleVerFlagYAG { get; set; }
        public static string LpOrLpcYAG { get; set; }
        public static int EnergyMaxYAG { get; set; }
        public static int Average_PowerMaxYAG { get; set; }
        public static int EnergyMinYAG { get; set; }

        public static string TempCT { get; set; }

        public static bool ErrorOnWarmUp { get; set; } = false;
        public static int NextTimeIntervalCalib { get; set; }

        public static bool IsCalibLoaded { get; set; } = false;
        public static DateTime NextCalibDateTime { get; set; }
        public static string LastCalibDateTime { get; set; }
        public static int TimeIntervalCalib { get; set; }

        public static bool IsCalibLoadedYAG { get; set; } = false;
        public static DateTime NextCalibDateTimeYAG { get; set; }
        public static string LastCalibDateTimeYAG { get; set; }
        public static int TimeIntervalCalibYAG { get; set; }

        public static bool IsDashboardLoaded { get; set; } = false;

        public static bool IsWarmupLoaded = false;

        public static bool IsLaserConnected { get; set; } = true;


        public static bool IsLoginPopUp { get; set; } = false;

        public static int ProgressBarText = 0;
        //public static SQLiteConnection Sqlite_connection = null;
        public static DateTime StartTime { get; set; }

        public static int Fluence { get; set; } = 0; // This needs to be revisited 
        public static int FluenceMax = 41;
        public static int FluenceMin = 0;
        public static int duration { get; set; } = 3; // This needs to be revisited 
        public static int DurationMax = 300;
        public static int DurationMin = 0;
        public static double pulseRate { get; set; } = 1; // This needs to be revisited 
        public static double PulseRateMax = 100;
        public static double PulseRateMin = 1;

        public static float StandoffAlex { get; set; } = 0;
        public static bool HandPieceSelectedAlex = false;

        public static float StandoffYAG { get; set; }
        public static bool HandPieceSelectedYAG = false;

        public static bool CalibAlexSuccess = true; // "Hardcoaded" Dependent on calibration screen "If true then hardcoaded"
        public static bool CalibYagSuccess = true;  // "Hardcoaded" Dependent on calibration screen "If true then hardcoaded"

        public static bool ModeReadyAlex = false;
        public static bool ModeStandByAlex = false;
        public static bool ModeOffAlex = false;

        public static bool ModeReadyYAG = false;
        public static bool ModeStandByYAG = true;
        public static bool ModeOffYAG = false;

        public static long MasterShotCountAlex { get; set; }

        // Not implemented "Hardcoded"
        /*Amartya
         This code will be revisited again during patient data form story
        */
        public static string ProcedureName { get; set; } = "Hair";
        public static int ProcedureCode { get; set; } = 007;
        public static int OperatorCode { get; set; } = 404;
        public static int ShotsUsed { get; set; } = 20;
        public static int ProcedurePrice { get; set; } = 5000;
        public static int PricePerHour { get; set; } = 500;
        public static int PricePerShot { get; set; } = 10;

        public static string SkinType = String.Empty;
        public static string HairType = String.Empty;
        public static string HairDense = String.Empty;
        public static string HairGrade = String.Empty;

        public static long ShotCount { get; set; } = 100;
        public static bool UserInterlockFlag { get; set; }
        public static byte PrimaryCause { get; set; }
        public static string DoorRightColor { get; set; }

        public static string DoorTopColor { get; set; }

        public static string RemoteInterlockColor { get; set; }
        public static string CoolantLevelColor { get; set; }
        public static string CoolantOverTemp1Color { get; set; }
        public static string CoolantFlowColor { get; set; }
        public static string CoolantFlowCaption { get; set; }
        public static bool Flowswitch_Flag { get; set; } = true;
        public static bool Flowswitch_Flag_Override { get; set; } = true;
        public static string CoolantTemperatureColor { get; set; }
        public static string CoolantOverTemp2Color { get; set; }
        public static string UserInterfaceColor { get; set; }
        public static string IoProcessorColor { get; set; }
        public static string InternalYagColor { get; set; }
        public static string InternalAlexColor { get; set; }
        public static string ShutterCaption { get; set; }
        public static string FiberPortColor { get; set; }
        public static string ShutterColor { get; set; }

        public static string CalibrationPortCaption { get; set; }
        public static string CalibrationPortColor { get; set; }
        public static string PFNVoltageColor { get; set; }
        public static string EnergyColor { get; set; }
        public static string EmissionColor { get; set; }
        public static string PowerSupplyOverColor { get; set; }
        public static string PowerSupplyColor { get; set; }
        public static string SimmerColor { get; set; }
        public static bool ShowInterlock { get; set; }
        public static bool IsShowInterLock { get; set; } = false;

        public static bool ShowLoginPopUp { get; set; }

        public static string StrLaserType { get; set; } = "Alex";
        public static int Progress;
        public static bool DEMO_VERSION { get; set; }
        public static string FastWarmUpColor { get; set; }
        public static bool TimerEnabled { get; set; } = false;
        public static string DoorRightBackColor { get; set; }

        public static string DoorTopBackColor { get; set; }

        public static string RemoteInterlockBackColor { get; set; }
        public static string CoolantLevelBackColor { get; set; }
        public static string CoolantOverTemp1BackColor { get; set; }
        public static string CoolantFlowBackColor { get; set; }
        public static string CoolantTemperatureBackColor { get; set; }
        public static string CoolantOverTemp2BackColor { get; set; }
        public static string UserInterfaceBackColor { get; set; }
        public static string IoProcessorBackColor { get; set; }
        public static string InternalYagBackColor { get; set; }
        public static string InternalAlexBackColor { get; set; }
        public static string ShutterBackColor { get; set; }
        public static string FiberPortBackColor { get; set; }

        public static string CalibrationPortBackColor { get; set; }
        public static string PFNVoltageBackColor { get; set; }
        public static string EnergyBackColor { get; set; }
        public static string EmissionBackColor { get; set; }
        public static string PowerSupplyOverBackColor { get; set; }
        public static string PowerSupplyBackColor { get; set; }
        public static string SimmerBackColor { get; set; }
        public static bool WarmCalibFlag { get; set; }
        public static bool IsProgressComplete { get; set; }
        public static int MinimumValue { get; set; } = 0;

        public static bool CalibInterlockFlag { get; set; } = true;
        public static int PsFlag { get; set; }
        public static string LpOrLpc { get; set; }

        public static double CalibRatio { get; set; }
        public static double CalibRatio1 { get; set; }
        // Till here 

        // calibAlex

        //

        public static int RecomFluence { get; set; }
        public static int RecomDuration { get; set; }
        public static int LogFileNumber { get; set; }
        public static string OperatorName { get; set; }
        public static int CertificationLevel { get; set; }
        public static int MASTER_SHOT_COUNT { get; set; }
        public static bool IsBeginProcedure { get; set; } = false;
        public static bool IsStopProcedure { get; set; } = false;
        public static bool EnableRecomSetting { get; set; } = false;
        public static int ProFlag2 { get; set; }
        public static long LongShotStartUsed { get; set; }
        public static long ShotUsedNon { get; set; }
        public static bool PatientRecomSettings { get; set; } = true;

        public static bool IsBeginStopProcedure { get; set; } = false;
        public static float HoldHandPieceValue { get; set; } = 0;
        public static string PatientFileNumber { get; set; }

        public static bool DisplayPatientEndProcRecomSetting { get; set; } = false;
        public static int BKPmasterShotCt { get; set; } = 0;
        public static double Calport_Pd_Ratio_3Y { get; set; }
        public static double Calport_Pd_Ratio_10Y { get; set; }
        public static double Calport_Pd_Ratio_50Y { get; set; }
        public static double Calport_Pd_Ratio_100Y { get; set; }
        public static double Calport_Pd_Ratio_300Y { get; set; }
        public static double Calport_Pm_Ratio_Y { get; set; }
        public static string StrLongOrShort { get; set; }
        public static double PFNcap { get; set; }
        public static int P_Supply { get; set; }
        public static int Supply_volt { get; set; }
        public static int Limit_volt { get; set; }
        public static int E_LIMIT_3 { get; set; }
        public static int TempSet { get; set; }
        public static bool P_MeterFlag { get; set; }
        public static bool SimpleVerFlag { get; set; }

        public static int EnergyMax { get; set; }
        public static int Average_PowerMax { get; set; }
        public static int EnergyMin { get; set; }
        public static string FileNumber { get; set; }
        public static bool IsInitialize { get; set; } = false;

        //Btn disable variable for Alex and Yag cal port
        public static bool IsDisabled { get; set; } = false;
        public static bool Btndisabled { get; set; } = false;
        public static string SystemDate { get; set; }
        public static string MaxDate { get; set; }

        public static DateTime NotificationDate { get; set; }

        public static double ValueAlex { get; set; }
        public static double CalValueAlex { get; set; }

        public static double ValueYag { get; set; }
        public static double CalValueYag { get; set; }
        public static long intSetUpShotCt { get; set; }
        public static bool IsCalibrationAndDiagnosisLoaded = false;
        public static string DuoAlexOrYag { get; set; }

        public static string TimeIn { get; set; } = DateTime.Now.ToString("hh:mm tt");
        public static string TechnicianName { get; set; }
        public static bool IsTechModeLogLoaded { get; set; } = false;
        public static long ShotCtLogInAlex { get; set; }
        public static long ShotCtLogInYag { get; set; }
        public static long MasterShotCountYag { get; set; }

    }
    public static class RegistryConfigurationTypes
    {
        public static string EnergyMonitor = "OFF";
        public static string AlexTechModeEntered = "True";
        public static string EnergyDataLogDate = DateTime.Today.ToString("MM/dd/yyyy");
        public static string YagTechModeEntered = "False";
    }

    public enum INTERLOCK
    {
        INTERLOCK_NONE,
        INTERLOCK_RIGHT_DOOR_OPEN,
        INTERLOCK_TOP_DOOR_OPEN,
        INTERLOCK_LEFT_DOOR_OPEN,
        INTERLOCK_REMOTE_DOOR_OPEN,
        INTERLOCK_COOLANT_LEVEL_FAULT,
        INTERLOCK_COOLANT_OVERTEMP,
        INTERLOCK_COOLANT_FLOW,
        INTERLOCK_COOLANT_TEMPERATURE_SENSOR_OPEN,
        INTERLOCK_COOLANT_OVERTEMP_1,
        INTERLOCK_USER_INTERFACE_COMMUNICATION_ERROR,
        INTERLOCK_IO_PROCESSOR_COMMUNICATION_ERROR,
        INTERLOCK_IR_SHUTTER_POSITION_SENSOR,
        INTERLOCK_INTERNAL_SHUTTER_POSITION_SENSOR,
        INTERLOCK_EXTERNAL_SHUTTER_POSITION_SENSOR,
        INTERLOCK_FIBER_PORT_SWITCH_OPEN,
        INTERLOCK_CALIBRATION_PORT_HANDPIECE_SENSE,
        INTERLOCK_PFN_VOLTAGE_MONITORING,
        INTERLOCK_ENERGY_MONITORING,
        INTERLOCK_LASER_WARNING_LED,
        INTERLOCK_POWER_SUPPLY_OVER_TEMPERATURE,
        INTERLOCK_POWER_SUPPLY_OVER_VOLTAGE,
        INTERLOCK_SIMMER_FAILURE,
        INTERLOCK_COUNT
    }

    public enum STATE_COMMAND
    {
        STATE_COMMAND_OFF = 0,
        STATE_COMMAND_STANDBY,
        STATE_COMMAND_FAST_WARM_UP,
        STATE_COMMAND_READY,
        STATE_COMMAND_COUNT
    }
}