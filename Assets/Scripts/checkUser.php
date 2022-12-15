<?php
include "dbConnection.php";



$userName = $_POST['userName'];
$pass = hash("sha256", $_POST['pass']);

$sql = "SELECT userName FROM game.usuarios WHERE userName = '$userName' AND password = '$pass'";
$result = $pdo->query($sql);

if($result->rowCount() > 0)
{
    $data = array('done' => true , 'message' => "Bienvenido");
    header('Content-Type: application(json');
    echo json_encode($data);
    exit();
}

else 
{
    $data = array('done' => false , 'message' => "Nombre de usuario o contraseña incorrectos");
    header('Content-Type: application(json');
    echo json_encode($data);
    exit();
}

?>