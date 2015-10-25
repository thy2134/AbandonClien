using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xgoogleSharp;

namespace AbandonClien
{
    class Program
    {
        static void Main(string[] args)
        {
            Clien clien;

            while(true)
            {
                string id;
                string pw;

                Console.Write("면책 조항 : 이 툴은 구글 검색을 이용하여 모두의 공원 게시판에서의 댓글을 찾아 삭제합니다. \n");
                Console.Write(" 이 과정에서 구글 검색엔진의 실수로 인하여 간혹 다른 게시판의 댓글이 사라질 수 있으며, 이에 대해 본 제작자는 책임을 지지 않습니다. \n");
                Console.Write("이 프로그램에서 최종 확인 질문 따위는 없습니다. 취소하고 싶으시면 검색 과정에서 Ctrl+C를 누르거나 그냥 창을 끄세요. \n");

                Console.Write("\n 클리앙 아이디: ");
                id = Console.ReadLine();

                Console.Write("클리앙 암호: ");
                pw = Console.ReadLine();

                clien = new Clien(id,pw);
                var loginTask = clien.Login();
                loginTask.Wait();

                if ( loginTask.Result == false )
                {
                    Console.WriteLine("로그인 실패... 아이디 암호를 다시 확인하세요.");
                }

                Console.WriteLine("로그인 성공... 글을 수집합니다.");
                break;
            }
            
            var de = new DestroyEverything(clien);
            de.Collect().Wait();

            if ( de.Describe() == true )
            {
                de.Destroy().Wait();
            }

            Console.WriteLine("<엔터>키를 누르면 종료합니다.");
            Console.ReadLine();
        }
    }
}
