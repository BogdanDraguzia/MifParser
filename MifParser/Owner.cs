using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MifParser
{
    public class Owner
    {
        #region 66 columns of hell

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ObjectId { get; set; }

        public int? PgId { get; set; }

        public double? X { get; set; }
        public double? Y { get; set; }

        [StringLength(2048)] public string PName { get; set; }
        public int? OrId { get; set; }

        [StringLength(2048)] public string OrTime { get; set; }

        public int? PcId { get; set; }
        public int? PcPgId { get; set; }
        public int? PcPgIdDoc { get; set; }
        public int? PcLayer { get; set; }
        public int? RValid { get; set; }
        public int? PcZIdCad { get; set; }
        public int? PcNumber { get; set; }


        [StringLength(2048)] public string PcFullNumber { get; set; }

        [StringLength(2048)] public string PcNumberOld { get; set; }
        [StringLength(2048)] public string PcCurrZoneAdmShort { get; set; }
        [StringLength(2048)] public string PcCurrZoneAdm { get; set; }
        [StringLength(2048)] public string PcCurrZoneGarden { get; set; }
        [StringLength(2048)] public string PcZoneAdm { get; set; }
        [StringLength(2048)] public string PcZoneGarden { get; set; }
        [StringLength(2048)] public string PcLanders { get; set; }
        [StringLength(2048)] public string PcfLanderCodes { get; set; }
        [StringLength(2048)] public string PcfLanderPassports { get; set; }
        [StringLength(2048)] public string PcfLanderAddresses { get; set; }
        [StringLength(2048)] public string PcfRights { get; set; }
        [StringLength(2048)] public string PcfRightdateSt { get; set; }
        [StringLength(2048)] public string PcfRightdateEn { get; set; }

        public int? PcfRightFlags { get; set; }

        [StringLength(2048)] public string PcfParts { get; set; }
        [StringLength(2048)] public string PcfDescription { get; set; }
        [StringLength(2048)] public string PcAddress { get; set; }
        [StringLength(2048)] public string PcDcKind { get; set; }
        [StringLength(2048)] public string PcDcNumber { get; set; }
        [StringLength(2048)] public string PcfDcRegnum { get; set; }
        [StringLength(2048)] public string PcfDcRegdate { get; set; }
        [StringLength(2048)] public string PcfDcChangeDate { get; set; }
        [StringLength(2048)] public string PcfGroup { get; set; }
        [StringLength(2048)] public string PcfPurpose { get; set; }
        [StringLength(2048)] public string PcfTargetPurpose { get; set; }

        public int? PcHtId { get; set; }

        [StringLength(2048)] public string PcfFolder { get; set; }
        [StringLength(2048)] public string PcsSquare { get; set; }
        [StringLength(2048)] public string PcsDocSquare { get; set; }
        [StringLength(2048)] public string PcsRealSquare { get; set; }
        [StringLength(2048)] public string PcfDcNumberJur { get; set; }
        [StringLength(2048)] public string PcfDcDateJur { get; set; }
        [StringLength(2048)] public string RLnId { get; set; }
        [StringLength(2048)] public string RRight { get; set; }

        public int? PcPllMask { get; set; }
        public int? PcExistsGa { get; set; }

        [StringLength(2048)] public string RFlags { get; set; }
        [StringLength(2048)] public string RUsage { get; set; }
        [StringLength(2048)] public string PcfLanderFolders { get; set; }
        [StringLength(2048)] public string PcfDcNumberAggrav { get; set; }
        [StringLength(2048)] public string PcfLandersComm { get; set; }
        [StringLength(2048)] public string PcfDcNumberComm { get; set; }

        public double? PcfDcRegnumComm { get; set; }

        [StringLength(2048)] public string PcfDcRegdateComm { get; set; }
        [StringLength(2048)] public string PcfCadnumDcKind { get; set; }
        [StringLength(2048)] public string PcfCadnumDcNumber { get; set; }
        [StringLength(2048)] public string PcfCadnumDcDate { get; set; }
        [StringLength(2048)] public string PcfGrounds { get; set; }

        [StringLength(200)] public string FMatchedRecords { get; set; }

        public double? StAreaShape { get; set; }
        public double? StLengthShape { get; set; }

        #endregion

        public int? PointId { get; set; }
        public ICollection<Point> Points { get; set; }

        public Owner(string[] arr)
        {
            int.TryParse(arr[0], out var objectId);

            ObjectId = objectId;
            PgId = MyParser.ParseNullableInt(arr[1]);
            X = MyParser.ParseNullableDouble(arr[2]);
            Y = MyParser.ParseNullableDouble(arr[3]);
            PName = arr[4];
            OrId = MyParser.ParseNullableInt(arr[5]);
            OrTime = arr[6];
            PcId = MyParser.ParseNullableInt(arr[7]);
            PcPgId = MyParser.ParseNullableInt(arr[8]);
            PcPgIdDoc = MyParser.ParseNullableInt(arr[9]);
            PcLayer = MyParser.ParseNullableInt(arr[10]);
            RValid = MyParser.ParseNullableInt(arr[11]);
            PcZIdCad = MyParser.ParseNullableInt(arr[12]);
            PcNumber = MyParser.ParseNullableInt(arr[13]);
            PcFullNumber = arr[14];
            PcNumberOld = arr[15];
            PcCurrZoneAdmShort = arr[16];
            PcCurrZoneAdm = arr[17];
            PcCurrZoneGarden = arr[18];
            PcZoneAdm = arr[19];
            PcZoneGarden = arr[20];
            PcLanders = arr[21];
            PcfLanderCodes = arr[22];
            PcfLanderPassports = arr[23];
            PcfLanderAddresses = arr[24];
            PcfRights = arr[25];
            PcfRightdateSt = arr[26];
            PcfRightdateEn = arr[27];
            PcfRightFlags = MyParser.ParseNullableInt(arr[28]);
            PcfParts = arr[29];
            PcfDescription = arr[30];
            PcAddress = arr[31];
            PcDcKind = arr[32];
            PcDcNumber = arr[33];
            PcfDcRegnum = arr[34];
            PcfDcRegdate = arr[35];
            PcfDcChangeDate = arr[36];
            PcfGroup = arr[37];
            PcfPurpose = arr[38];
            PcfTargetPurpose = arr[39];
            PcHtId = MyParser.ParseNullableInt(arr[40]);
            PcfFolder = arr[41];
            PcsSquare = arr[42];
            PcsDocSquare = arr[43];
            PcsRealSquare = arr[44];
            PcfDcNumberJur = arr[45];
            PcfDcDateJur = arr[46];
            RLnId = arr[47];
            RRight = arr[48];
            PcPllMask = MyParser.ParseNullableInt(arr[49]);
            PcExistsGa = MyParser.ParseNullableInt(arr[50]);
            RFlags = arr[51];
            RUsage = arr[52];
            PcfLanderFolders = arr[53];
            PcfDcNumberAggrav = arr[54];
            PcfLandersComm = arr[55];
            PcfDcNumberComm = arr[56];
            PcfDcRegnumComm = MyParser.ParseNullableDouble(arr[57]);
            PcfDcRegdateComm = arr[58];
            PcfCadnumDcKind = arr[59];
            PcfCadnumDcNumber = arr[60];
            PcfCadnumDcDate = arr[61];
            PcfGrounds = arr[62];
            FMatchedRecords = arr[63];
            StAreaShape = MyParser.ParseNullableDouble(arr[64]);
            StLengthShape = MyParser.ParseNullableDouble(arr[65]);
        }
        public Owner() {}
    }
}