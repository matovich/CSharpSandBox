using System;

namespace SandBox
{
    public class LoopCheck
    {
        public void Work()
        {
            //        ' For each bed in train, admit a patient to train beds Train1 to Train175
            //Public Function localpurge (patientid)

            //   CPNServer  = GetEnv("QSUPDATE")
            //    strCmd = "QSMAN *" & CPNServer & "* PDSS SET PURGE=" & patientid 
            //    print strCmd
            //    RunCmd(strCmd)
            //    wait 10

            //End Function

        
            int r = 1;
           

            //r=1
            //For i=1 to 175

            for (int i = 1; i <= 175; i++)
            {
                Console.WriteLine("Patient {0} r {1}", i, r);
            }
            //    FLOW_Admit_Patient_HL7 "adttest"&i&"r"&r, "LastName"&i&"r"&r, "FirstName"&i&"r"&r, "Train", "Train"&i
            //    print "Admitted patient " & "adttest"&i&"r"&r
            //    wait 15
            //Next

            //wait 5
            //'update wait as needed

            

            //For outerloop=2 to 500

            for (int i = 2; i < 6; i++)
            {

                //    For j=1 to 175
                for (int j = 1; j <= 175; j++)
                {
                 

                    Console.WriteLine("Discharge {0} r {1}", j , r);
                //'	 Discharge patient 
                //    FLOW_Discharge_Patient_HL7 "adttest"&j&"r"&r,  "LastName"&j&"r"&r, "FirstName"&j&"r"&r, "Train", "Train"&j
                //    print "Discharge " & "adttest"&j&"r"&r& " " & now
                //    wait 10

                    r = i;

                    Console.WriteLine("Admit {0} r {1}", j, r);

                    //    r=outerloop
                    //    FLOW_Admit_Patient_HL7 "adttest"&j&"r"&r, "LastName"&j&"r"&r, "FirstName"&j&"r"&r, "Train", "Train"&j
                    //    print "Admitted patient " & "adttest"&j&"r"&r & " " & now
                    //    r=outerloop-1	
                    r = i - 1;
                    //    wait 300

                    Console.WriteLine();
                    //    Next
                    //Next

                }

                Console.WriteLine("===========================");
            }
        }
    }
}
