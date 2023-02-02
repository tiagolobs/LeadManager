import { Box, Button, makeStyles } from "@material-ui/core";
import React from "react";
import CardPrice from "./CardPrice";

interface Props {
  price: number;
  leadId: number;
  handleUpdate: (id: number, accepted: boolean) => void;
}

const useStyles = makeStyles((theme) => ({
  root: {
    display: "flex",
    alignItems: "center",
    padding: theme.spacing(2),
  },
  buttonDecline: {
    marginRight: theme.spacing(2),
    background: "#EEEEEE",
    borderRadius: 0,
    border: "none",
    boxShadow: "0px 1px 0px 0px grey",
    textTransform: "none",
  },
  buttonAccept: {
    marginRight: theme.spacing(1),
    background: "#FE7D2B",
    color: "white",
    borderRadius: 0,
    boxShadow: "0px 1px 0px 0px grey",
    textTransform: "none",
  },
}));

const CardButtons: React.FC<Props> = ({ price, leadId, handleUpdate }) => {
  const classes = useStyles();

  return (
    <Box className={classes.root}>
      <Box>
        <Button
          variant="contained"
          onClick={() => handleUpdate(leadId, true)}
          className={classes.buttonAccept}
        >
          Accept
        </Button>
        <Button
          variant="outlined"
          color="default"
          onClick={() => handleUpdate(leadId, false)}
          className={classes.buttonDecline}
        >
          Decline
        </Button>
        <CardPrice price={price}></CardPrice>
      </Box>
    </Box>
  );
};

export default CardButtons;
