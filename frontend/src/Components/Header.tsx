import {
  AppBar,
  Toolbar,
  Typography,
} from "@material-ui/core";

export default function Header() {

  return (
    <AppBar position="static">
      <Toolbar>
        <Typography variant="h6">
          Car Project
        </Typography>
      </Toolbar>
    </AppBar>
  );
}
