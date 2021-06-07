

import java.io.IOException;

import controller.CmdController;
import model.CmdModel;
import view.CmdView;

public class CmdMain {

	public static void main(String[] args) throws IOException, InterruptedException {
		// TODO Auto-generated method stub
		
		CmdView view = new CmdView();
		CmdModel model = new CmdModel();
		CmdController controller = new CmdController(view,model);
	}

}
