<?php
include "dbConnection.php";

$userName = $_POST['userName'];
$email  = $_POST['email'];
$pass = hash("sha256" , $_POST['pass']);

$sql = "SELECT userName From game.usuarios WHERE userName = '$userName'";
$result = $pdo->query($sql);

if($result->rowCount() > 0)
{
    $data = array('done' => false , 'message' => "Error nombre de usuario ya existe");
    header('Content-Type: application(json');
    echo json_encode($data);
    exit();
}

else
{
    $sql = "SELECT email From game.usuarios WHERE email = '$email'";
    $result = $pdo->query($sql);

    if($result->rowCount() >0 )
    {
    $data = array('done' => false , 'message' => "Error email ya existe");
    header('Content-Type: application(json');
    echo json_encode($data);
    exit();
    }
    else 
    {
        $sql = "INSERT INTO game.usuarios SET userName = '$userName' , email = '$email' , password = '$pass'";
        $pdo->query($sql);

        $data = array('true' => false , 'message' => "Usuario creado");
        header('Content-Type: application(json');
        echo json_encode($data);
        exit();
    }
}

?>