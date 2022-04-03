using System;

namespace JogoDaVelhaC_
{
    class Program
    {
        public static void clearConsole(){
		for (int i = 0; i < 20; i++) {
			Console.WriteLine();
		}
	    }
        public static bool  playAgain(){
		Console.WriteLine();
		Console.WriteLine("Para jogar novamente digite 1 para sair digite 2!");
		return (int.Parse(Console.ReadLine()) == 1) ?  true:  false;
	}
        static void Main(string[] args)
        {
            Board board = new Board();
		
		    bool flag = true;
		    Console.WriteLine("Para fazer uma jogada digite uma coordenada de '1 1' à '3 3' no formato linha seguido de coluna");
		    while(flag){
                char jogador;
                //Alterna jogadores
                Console.WriteLine("--------------------");
                if(Board.numOfMoves%2 == 0)
                {				
                    Console.WriteLine("Vez do jogador X");
                    jogador = 'X';
                }else{
                    Console.WriteLine("Vez do jogador O.");
                    jogador = 'O';
                }
                Console.WriteLine("--------------------");
                Console.WriteLine("Digite uma coordenada de '1 1' à '3 3' que ainda não foi usada!");
                board.showBoard();

                String coord = Console.ReadLine();
                coord = coord.Trim().Replace(" ","");
                int x = 0;
                int y = 0;
                
                if(coord.Length >= 2){
                    x = int.Parse(coord[0].ToString())-1;
                    y = int.Parse(coord[1].ToString())-1;;
                }
                
                if(x < 0 || x > 2 || y < 0 || y > 2){
                    clearConsole();
                    Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    Console.WriteLine("Para fazer uma jogada digite uma coordenada de '1 1' à '3 3' no formato linha seguido de coluna");
                    Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    continue;
                }

                
                //Caso a jogada aconteça aumenta o contador.
                if(board.play(x, y, jogador)){
                    Board.numOfMoves++;
                }else{
                    continue;
                }
                
                //Verifica final da partida somente a partir da quinta jogada.
                if(Board.numOfMoves > 4){
                    if(board.verifyBoard()){
                        clearConsole();
                        Console.WriteLine("\nJogador " +jogador + " venceu!\n");
                        board.showBoard();
                        board = new Board();
                        flag = playAgain();                        
                    }
                    if(Board.numOfMoves >= 9){
                        clearConsole();
                        Console.WriteLine("Deu velha!");
                        board = new Board();
                        flag = playAgain();
                    }
                }
            }
        }
    }
}
