using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System;

public class TestFolder : MonoBehaviour
{
    public void Test()
    {

        Process.Start("explorer.exe", "https://ggm.gondr.net/user/profile/303");

        Process ExternalProcess = new(); // procss�� �����Ű�� �ν��Ͻ� ����
        ExternalProcess.StartInfo.FileName = @"C:\Users\�迬ȣ\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Steam";
        ExternalProcess.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
        ExternalProcess.Start();
        ProcessStartInfo startInfo = new(@"C:\Program Files (x86)\Steam\steam.exe");
        //startInfo.Arguments = "www.naver.com";
        startInfo.WindowStyle = ProcessWindowStyle.Minimized;
        Process.Start(startInfo);


        //ExternalProcess.StartInfo.FileName = @"C:\Users\�迬ȣ\Pictures\���";
        //ExternalProcess.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;

        //ExternalProcess.Start();

        //����������
        //System.Diagnostics.Process.Start("cmd.exe", "ShutDown.exe -s -f -t 00");


        //�����
        //System.Diagnostics.Process.Start("cmd.exe", "ShutDown.exe -r -f -t 00");

        //������ɾ� ����
        //System.Diagnostics.Process.Start("cmd.exe", "/c dir");

        //Process myProcess = new Process();
        //string myDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        //myProcess.StartInfo.FileName = myDocumentsPath + @"\MyFile.doc";
        //myProcess.StartInfo.Verb = "Print"; //���� �� ���� ���� ��?��
        //myProcess.StartInfo.CreateNoWindow = true; //�����츦 ���� ������ΰ�
        //myProcess.Start();
    }
    
}
