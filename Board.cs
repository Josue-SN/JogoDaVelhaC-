using System;

namespace JogoDaVelhaC_
{
    class Board
    {
		 private char[,] board;
		public static int numOfMoves;

		public Board(){
			board = new char[3,3];
			for (int i = 0; i < board.GetLength(0); i++) {
				for (int j = 0; j < board.GetLength(1); j++) {
					board[i,j] = '-';
				}
			}
			numOfMoves = 0;
		}
		public bool verifyBoard(){
		//Verifica as linhas
		for (int i = 0; i < board.GetLength(0); i++) {
			if(board[i,0] == board[i,1] && board[i,1] == board[i,2] && board[i,2] != '-'){
				return true;
			}
		}

		//Verifica as colunas
		for (int i = 0; i < board.GetLength(1); i++) {
			if(board[0,i] == board[1,i] && board[1,i] == board[2,i] && board[2,i] != '-'){
				return true;
			}
		}

		//Diagonais
		if(board[0,0] == board[1,1] && board[1,1] == board[2,2] && board[2,2] != '-'){
			return true;
		}

		if(board[0,2] == board[1,1] && board[1,1] == board[2,0] && board[2,0] != '-'){
			return true;
		}

		return false;
	}

	public void showBoard(){
		for (int i = 0; i < board.GetLength(0); i++) {
			for (int j = 0; j < board.GetLength(1); j++) {				
				if(j!=2){
					Console.Write("{0} . ", board[i,j]);
				}else{
					Console.Write("{0}\n", board[i,j]);
				}
			}
		}		
	}

	public bool play(int X, int Y, char jogador){
		if(board[X,Y]=='-'){
			board[X,Y] = jogador;
			return true;
		}			
		return false;	
	}


	}
}
