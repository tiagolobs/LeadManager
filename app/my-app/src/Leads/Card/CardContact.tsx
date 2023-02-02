import React from "react";
import { makeStyles, Typography, Box } from "@material-ui/core";
import EmailIcon from "@material-ui/icons/EmailOutlined";
import TelephoneIcon from "@material-ui/icons/CallOutlined";

interface Props {
  phoneNumber: string;
  email: string;
}

const useStyles = makeStyles((theme) => ({
  root: {
    display: "flex",
    alignItems: "center",
    padding: theme.spacing(2),
  },

  iconText: {
    fontWeight: "bold",
    marginRight: theme.spacing(10),
    color: "#FE7D2B",
  },
  date: {
    marginTop: theme.spacing(1),
  },
}));

const CardContact: React.FC<Props> = ({ phoneNumber, email }) => {
  const classes = useStyles();

  return (
    <Box className={classes.root}>
      <TelephoneIcon />
      <Typography variant="body2" component="span" className={classes.iconText}>
        {phoneNumber}
      </Typography>
      <EmailIcon />
      <Typography variant="body2" component="span" className={classes.iconText}>
        {email}
      </Typography>
    </Box>
  );
};

export default CardContact;
