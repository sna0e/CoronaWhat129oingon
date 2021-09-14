using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogue
{

    //�⺻������ ������ ��� �Լ��� �ѹ��� �������ִ� Init �Լ�"void Init()"
    public static void Init()
    {
        first();
        friend_t();
        order_t();
        st();
        cf();
        sub();
        text();
    }

    //���� ������ ���� ��� ������ 0���� �ʱ�ȭ���ִ� ResetScore�Լ� "void ResetScore()"

    public static Dictionary<string, string> phone = new Dictionary<string, string>();
    static void first()
    {
        phone.Add("a_p", "5�� 20�п� �б� �� ī�信�� ����! ������!");//ù��° ��Ÿ� ������ ����
        phone.Add("b_p", "����ö ���� 3�� ��"); //��Ÿ� 1 ������ ��(����ö �Ѿ�� ��)
        phone.Add("c_p", "���Ǵ� �Ա����� �����߽��ϴ�, ������ �˶��� �����մϴ�.");//����ö ������ ��(�ι�° ��Ÿ� ������)
        phone.Add("d_p", "����: ���� ���� ����? �����ؼ� ��~");//����° ��Ÿ� ���� �� ����
    }



    public static Dictionary<string, string> friend = new Dictionary<string, string>();// ī�信�� ģ����� ��ȭ ����
    static void friend_t()
    {
        //1
        friend.Add("a_f", "�츮 ��¥ �������̴�. �� ���¾�?");
        friend.Add("b_f", "�� ��, ���� �þ�? �Ÿ��α� 4�ܰ� �����Ѵ�!");
        //2
        friend.Add("c_f", "�ٵ� ���� ���ƴٴϴ� ���� �濪��Ģ�� �� �������� �ʴ� �� ����.");
        friend.Add("d_f", "��ġ, Ư�� ������������ �׷���, ��Ÿ�������!");
        friend.Add("e_f", "���� �𸣰� �Ѿ�� �濪��Ģ�� �� ���Ҿ�!");
        //3
        friend.Add("f_f", "�ڷγ� Ȯ���� ���������� ���ھ�...");
        friend.Add("g_f", "���� �ؿܿ����̳� �������� ���� �ٴϰ�;�!");
        friend.Add("h_f", "�� �׷� �ź��� ����ũ�� ���� �������� ���ھ�! �ʹ� �����.");
        friend.Add("i_f", "�׷� ���� �� ������?");
        //ī�� ���� �� ������ ��ȭ (����° ��Ÿ��� �Ѿ�� ��)
        friend.Add("j_f", "���� �������� �ʹ� ��ſ���!");
        friend.Add("k_f", "��, �� �� ������ �ƽ����� ��ſ���!");
        friend.Add("l_f", "�� ��!");
    }
    

    public static Dictionary<string, string> order = new Dictionary<string, string>();//ī�信�� �˹ٻ��� ��ȭ ����
    static void order_t()
    {
        //ť��üũ �� ī�� �˹ٻ��� ��ȭ 
        order.Add("a_o", "�ȳ��ϼ���~ ���ٹ��Դϴ�~ �ֹ��Ͻðھ��?");
        order.Add("b_o", "���̽� �Ƹ޸�ī�� �����̿�!");
        order.Add("c_o", "��ð� ���ó���?");
        order.Add("d_o", "��!");
        //ť��üũ �ȳ� ����(70% Ȯ����)
        order.Add("e_o", "��ð� ���ø� �����ʿ� QR üũ�� ��Ź�帮�ڽ��ϴ�!");

    }


    public static Dictionary<int, string> street_rule = new Dictionary<int, string>(); // ��Ÿ� �濪 ��ħ
    public static List<int> street_score = new List<int>();
    static void st()
    {
        street_score.Add(0);
        street_rule.Add(1, "�Ÿ��α� �ϸ� �ȱ�!");
        street_score.Add(0);
        street_rule.Add(2, "�����ϴ� ��� �Ű��ϱ�!");
        street_score.Add(0);
        street_rule.Add(3, "���ձ��� ���ؿ� ���� �ʴ� ��� �Ű��ϱ�!");
        street_score.Add(0);

    }

    

    public static Dictionary<int, string> cafe_rule = new Dictionary<int, string>(); //ī�� �濪 ��ħ
    public static List<int> cafe_score = new List<int>();
    static void cf()
    {
        cafe_score.Add(0);
        cafe_rule.Add(1, "�Ÿ��α�!");
        cafe_score.Add(0);
        cafe_rule.Add(2, "������� ����ũ ����!");
        cafe_score.Add(0);
        cafe_rule.Add(3, "QR üũ��!");
        cafe_score.Add(0);
    }


    public static Dictionary<int, string> subway_rule = new Dictionary<int, string>(); // ����ö �濪 ��ħ
    public static List<int> subway_score = new List<int>();
    static void sub()
    {
        subway_score.Add(0);
        subway_rule.Add(1, "�Ÿ��α�!");
        subway_score.Add(0);
        subway_rule.Add(2, "�ڸ� ��� �ɱ�!");
        subway_score.Add(0);
        subway_rule.Add(3, "��ȭ�ϴ� ��� ���ϱ�!");
        subway_score.Add(0);
    }


    public static Dictionary<int, string> isolation_text = new Dictionary<int, string>(); //�ڰ��ݸ� ���� ����

    static void text()
    {
        isolation_text.Add(1, "�ȳ��Ͻʴϱ�. �ۡ� ���Ǽ��Դϴ�. ���ϴ� �ڷγ� Ȯ���� ���� �ڰ��ݸ� ��������� �뺸�帳�ϴ�.");
        isolation_text.Add(2, "�ڰ��ݸ� �Ⱓ�� 2���̸� �˻� ����� ������� �ٱ� ������ �����˴ϴ�.");
    }

    

}