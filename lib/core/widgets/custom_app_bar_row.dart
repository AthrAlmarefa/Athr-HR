import 'package:flutter/material.dart';
import 'package:athr_hr/core/styles/colors/my_colors.dart';
import 'package:athr_hr/core/styles/fonts/my_fonts.dart';

class CustomAppBarRow extends StatelessWidget {
  final String title;
  final Widget? trailing;
  final VoidCallback? onPressed;

  const CustomAppBarRow({
    super.key,
    required this.title,
    this.trailing,
    this.onPressed,
  });

  @override
  Widget build(BuildContext context) {
    return Row(
      mainAxisAlignment: MainAxisAlignment.center,
      crossAxisAlignment: CrossAxisAlignment.center,
      children: [
        Expanded(
          child: Center(
            child: Text(
              title,
              style: MyFonts.styleBold700_20.copyWith(
                color: MyColors.black,
              ),
            ),
          ),
        ),
        if (trailing != null) InkWell(
          onTap: onPressed,
            child: trailing!),
      ],
    );
  }
}
