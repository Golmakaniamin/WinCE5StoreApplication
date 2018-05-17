// Prn_Borna.cpp : Defines the class behaviors for the application.
//

#include "stdafx.h"
#include "Prn_Borna.h"
#include "Prn_BornaDlg.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CPrn_BornaApp

BEGIN_MESSAGE_MAP(CPrn_BornaApp, CWinApp)
END_MESSAGE_MAP()


// CPrn_BornaApp construction
CPrn_BornaApp::CPrn_BornaApp()
	: CWinApp()
{
	// TODO: add construction code here,
	// Place all significant initialization in InitInstance
}


// The one and only CPrn_BornaApp object
CPrn_BornaApp theApp;

// CPrn_BornaApp initialization

BOOL CPrn_BornaApp::InitInstance()
{

	// Standard initialization
	// If you are not using these features and wish to reduce the size
	// of your final executable, you should remove from the following
	// the specific initialization routines you do not need
	// Change the registry key under which our settings are stored
	// TODO: You should modify this string to be something appropriate
	// such as the name of your company or organization
	SetRegistryKey(_T("Local AppWizard-Generated Applications"));

	CPrn_BornaDlg dlg;
	m_pMainWnd = &dlg;
	INT_PTR nResponse = dlg.DoModal();
	if (nResponse == IDOK)
	{
		// TODO: Place code here to handle when the dialog is
		//  dismissed with OK
	}

	// Since the dialog has been closed, return FALSE so that we exit the
	//  application, rather than start the application's message pump.
	return FALSE;
}
