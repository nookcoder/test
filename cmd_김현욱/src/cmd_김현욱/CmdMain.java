package cmd_±èÇö¿í;

import java.io.IOException;

import controller.CmdController;
import view.CmdView;

public class CmdMain {

	public static void main(String[] args) throws IOException {
		// TODO Auto-generated method stub
		
		CmdView view = new CmdView();
		CmdController controller = new CmdController(view);
	}

}
